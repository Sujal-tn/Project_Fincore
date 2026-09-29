using Fincore_Project.Data;
using Fincore_Project.Interface;
using Fincore_Project.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddScoped<IRoleService, RoleService>();
<<<<<<< HEAD
builder.Services.AddScoped<IAccountMasterService, AccountMasterService>();
=======
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout=TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential= true;
});


builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IVendorCategoryService, VendorCategoryService>();
builder.Services.AddScoped<IPRService, PRService>();

>>>>>>> 43803714ae3125a84af108e16f43d699381849c2
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
<<<<<<< HEAD
    pattern: "{controller=AccountMaster}/{action=Index}/{id?}")
=======
    pattern: "{controller=Auth}/{action=Login}/{id?}")
>>>>>>> 43803714ae3125a84af108e16f43d699381849c2
    .WithStaticAssets();


app.Run();

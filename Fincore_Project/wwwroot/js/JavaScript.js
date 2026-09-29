
$(document).ready(function () {
    $("#btnAdd").click(function () {
        $("#AddModal").modal("show");
    });

<<<<<<< HEAD


//Account Master Start

    $("#openmodal").click(function () {
        $("#AddModal").modal("show");
    });


    //Add Account

$("#addaccount").click(function (e) {

    e.preventDefault();

    var obj = $("#formadd").serialize();


    $.ajax({
        url: '/AccountMaster/AddAccount',
        type: 'POST',
        data: obj,
        dataType: 'json',
        success: function (res) {
            alert(res.message);
            $("#AddModal").modal('hide');
        },
        error: function () {
            alert("error");
        }
    });
    AccountMasterFetch();
});


//Update Account

    $("#updateaccount").click(function(e) {

        e.preventDefault();

        var obj = $("#formupdate").serialize();

        $.ajax({
            url: 'AccountMaster/Update',
            type: 'POST',
            dataType: 'json',
            data: obj,
            success: function (res) {
                alert(res.message);
                $("#UpdateModal").modal("hide");
                AccountMasterFetch();
            },
            error: function () {
                alert("Error");
            }
        });
    });

    AccountMasterFetch();

});


//Fetch All Account Data
function AccountMasterFetch() {

    $.ajax({

        url: '/AccountMaster/GetAccounts',
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            var obj = '';
            $.each(res, function (row, item) {
                obj += "<tr>";
                obj += "<td>" + item.accountId + "</td>";
                obj += "<td>" + item.accountCode + "</td>";
                obj += "<td>" + item.accountName + "</td>";
                obj += "<td>" + item.accountType + "</td>";
                if (item.isActive) {
                    obj += "<td><span class='badge bg-success'>Active</span></td>";
                }
                else {
                    obj += "<td><span class='badge bg-danger'>Inactive</span></td>";
                }
                obj += "<td>";

                obj += "<button class='btn btn-warning btn-sm' onclick='EditAccount(" + item.accountId + ")'>Edit</button> ";
                obj += "<button class='btn btn-danger btn-sm' onclick='DeleteAccount("+ item.accountId +")'>Delete</button>"; 

                obj += "</td>";
                obj += "</tr>";

            });
            $("#accountdata").html(obj);
        },
        error: function () {
            alert("Error");
        }

    });

}

//Edit Account
function EditAccount(id) {

    $.ajax({
        url: '/AccountMaster/Edit?id=' + id,
        type: 'GET',
        dataType: 'json',

        success: function (res) {

            $("#UpdateAccountId").val(res.accountId);
            $("#UpdateAccountName").val(res.accountName);
            $("#UpdateAccountType").val(res.accountType);
            $("#UpdateIsActive").val(res.isActive);

            $("#UpdateModal").modal("show");
        },
        error: function () {
            alert("Error");
        }
    });
}

//Delete Account

function DeleteAccount(id)
{
    var result = confirm("Are you sure you want to delete this account ?");

    if (result == false) {
        return;
    }

    $.ajax({
        url: 'AccountMaster/Delete?id=' + id,
        type: 'POST',
        dataType: 'json',
        success: function (res) {
            alert(res.message);
            AccountMasterFetch();
        },
        error: function () {
            alert("Error");
        }
    });
}


//Account Master End
=======
    $("#sbtn").click(function (e) {

        var obj = $("#roleform").serialize();
        $.ajax({
            url:'/Role/AddRole',
            type:'POST',
            data: obj,
            dataType: 'json',
            success: function (res) {
                alert(res);
                $("#AddModal").modal("hide");


            },
            error: function () {
                alert('Cannot Add');
            }


        });
    });

     $(document).on("click", ".editbtn", function () {

        var id = $(this).data("id");

        $.ajax({
            url: '/Role/GetRole',
            type: 'GET',
            data: { id: id },

            success: function (res) {

                if (res) {

                   $("#EditRoleId").val(res.roleId);
$("#EditRoleName").val(res.roleName);
$("#EditDescription").val(res.description);
$("#EditIsActive").val(res.isActive.toString());

                    $("#EditModal").modal("show");
                }
                else {
                    alert("Role Not Found");
                }
            },

            error: function () {
                alert("Cannot Get Role");
            }
        });

    });


    $("#ubtn").click(function(e){
        var obj = $("#editRoleForm").serialize();

         e.preventDefault();

         $.ajax({
        url: '/Role/EditRole',
        type: 'POST',
        data: obj,
          dataType: 'json',

         success: function (res){
             alert(res);
         },
         error:function(){
             alert("Cannot Update");
         },

        });
    });

    $("#editClose").click(function () {
        $("#EditModal").modal("hide");
    });

    $(document).on("click", ".delbtn", function () {

    var id = $(this).data("id");

    if (confirm("Are you sure you want to delete this role?")) {

        $.ajax({
            url: '/Role/DelRole',
            type: 'POST',
            data: { id: id },

            success: function (res) {

                alert(res);

                location.reload();
            },

            error: function () {

                alert("Cannot Delete Role");
            }
        });
    }
});

});


$(document).ready(function() {

    $('#btn').click(function() {
        $("#exampleModal").modal('show');
    });

    $('#closemodal').click(function() {
        $("#exampleModal").modal('hide');
    });

    $("#categoryform").submit(function(e) {

        e.preventDefault();   // IMPORTANT

        var obj = $(this).serialize();

        console.log(obj);

        $.ajax({
            url: '/VendorCategory/AddVendorCategory',
            type: 'POST',
            data: obj,
            dataType: 'json',

            success: function(response) {
                alert("Category added successfully!");

                $("#exampleModal").modal('hide');
                $("#categoryform")[0].reset();
               
            },

            error: function(xhr) {
                console.log(xhr);
                alert("Error");
            }
        });

    });

    
});

$(document).ready(function() {

    $('#btn').click(function() {
        $("#exampleModal").modal('show');
    });

    $('#closemodal').click(function() {
        $("#exampleModal").modal('hide');
    });

    $("#documentform").submit(function(e) {

        e.preventDefault();   // IMPORTANT

        var obj = $(this).serialize();

        console.log(obj);

        $.ajax({
            url: '/VendorCategory/AddDocumentType',
            type: 'POST',
            data: obj,
            dataType: 'json',

            success: function(response) {
                alert("document type added successfully!");

                $("#exampleModal").modal('hide');
                $("#documentform")[0].reset();

            },

            error: function(xhr) {
                console.log(xhr);
                alert("Error");
            }
        });

    });


});


$(document).ready(function() {

    $('#btn').click(function() {
        $("#exampleModal").modal('show');
    });

    $('#closemodal').click(function() {
        $("#exampleModal").modal('hide');
    });

    $("#PRform").submit(function(e) {

        e.preventDefault();   // IMPORTANT

        var obj = $(this).serialize();

        console.log(obj);

        $.ajax({
            url: '/PR/AddPR',
            type: 'POST',
            data: obj,
            dataType: 'json',

            success: function(response) {
                alert("document type added successfully!");

                $("#exampleModal").modal('hide');
                $("#PRform")[0].reset();

            },

            error: function(xhr) {
                console.log(xhr);
                alert("Error");
            }
        });

    });

});
>>>>>>> 43803714ae3125a84af108e16f43d699381849c2

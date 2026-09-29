using Fincore_Project.DTO;
using Fincore_Project.Models;

namespace Fincore_Project.Interface
{
    public interface IAuthService
    {
        Task<string> ResgisterUser(RegisterUserDto r);

        Task<User> LoginUser(LoginDto l);
    }
}

using Fincore_Project.Models;

namespace Fincore_Project.Interface
{
    public interface IRoleService
    {

        Task AddRole(Role r);
        Task DelRole(int id);

        Task<List<Role>> GetRoles();

        Task<Role> GetRoleById(int id);
        Task UpdateRole(Role role);
    }
}

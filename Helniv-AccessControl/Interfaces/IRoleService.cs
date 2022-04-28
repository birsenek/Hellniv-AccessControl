using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Models;
using Helniv_AccessControl.Services;

namespace Helniv_AccessControl.Interfaces
{
    public interface IRoleService
    {
        public void CreateRole(CreateRequestRoleModel roleModel);
        public IEnumerable<Role> GetAllRoles();
        public Role GetRoleByConst(string constant);
        public void UpdateRole(string roleConst, UpdateRequestRoleModel roleModel);
        public void DeleteRole(string roleConst);
    }
}

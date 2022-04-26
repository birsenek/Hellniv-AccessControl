using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Services;

namespace Helniv_AccessControl.Interfaces
{
    public interface IRoleService
    {
        public void CreateRole(CreateRequestRoleModel roleModel);
        public IEnumerable<Role> GetAllRoles();
    }
}

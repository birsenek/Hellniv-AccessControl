using AutoMapper;
using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Interfaces;
using Helniv_AccessControl.Utils;

namespace Helniv_AccessControl.Services
{
    public class RoleService : IRoleService
    {
        private HelnivDbContext _context;
        private Validation _validation;
        private readonly IMapper _mapper;

        public RoleService(HelnivDbContext context, Validation validation, IMapper mapper)
        {
            _context = context;
            _validation = validation;
            _mapper = mapper;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles;
        }

        public void CreateRole(CreateRequestRoleModel roleModel)
        {
            var role = _mapper.Map<Role>(roleModel);

            role.Active = true;

            _context.Roles.Add(role);
            _context.SaveChanges();
        }
    }
}

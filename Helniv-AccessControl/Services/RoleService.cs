using AutoMapper;
using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Interfaces;
using Helniv_AccessControl.Models;
using Helniv_AccessControl.Utils;
using Microsoft.EntityFrameworkCore;

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

        public Role GetRoleByConst(string constant)
        {
            var role = _context.Roles.AsNoTracking().Where(r => r.RoleConst.Equals(constant)).FirstOrDefault();
            
            if (role == null)
                throw new KeyNotFoundException("Perfil não encontrado");

            return role;

        }

        public void UpdateRole(string roleConst, UpdateRequestRoleModel roleModel)
        {
            var role = GetRoleByConst(roleConst);

            _mapper.Map(roleModel, role);
            _context.Update(role);
            _context.SaveChanges();
        }

        public void DeleteRole(string roleConst)
        {
            var role = GetRoleByConst(roleConst);

            _context.Remove(role);
            _context.SaveChanges();
        }
    }
}

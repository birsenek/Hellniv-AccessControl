using AutoMapper;
using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Interfaces;
using Helniv_AccessControl.Models;
using Helniv_AccessControl.Utils;

namespace Helniv_AccessControl.Service
{
    public class UserService : IUserService
    {
        private UserDbContext _context;
        private readonly IMapper _mapper;

        public UserService(UserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateUser(CreateRequestModel userModel)
        {
            //if (_context.Users.Any(x => x.Email == userModel.Email))
            //    throw new Exception($"Já existe um usuário cadastrado com o email {userModel.Email}");

            var user = _mapper.Map<User>(userModel);

            user.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);

            user.DataCriacao = DateTime.Now;

            user.Ativo = true;

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }
    }

}

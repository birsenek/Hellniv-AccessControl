using AutoMapper;
using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Interfaces;
using Helniv_AccessControl.Models;
using Helniv_AccessControl.Utils;
using Microsoft.EntityFrameworkCore;

namespace Helniv_AccessControl.Service
{
    public class UserService : IUserService
    {
        private UserDbContext _context;
        private Validation _validation;
        private readonly IMapper _mapper;

        public UserService(UserDbContext context, IMapper mapper, Validation validation)
        {
            _context = context;
            _validation = validation;
            _mapper = mapper;
        }

        public void CreateUser(CreateRequestModel userModel)
        {
            if(!_validation.ValidateUniqueEmail(userModel.Email))
                throw new Exception($"Já existe um usuário cadastrado com o email {userModel.Email}");

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

        public User GetUserByLogin(string userLogin)
        {
            var user = _context.Users.AsNoTracking().Where(x => x.Login == userLogin).FirstOrDefault();
            if (user == null)
                throw new KeyNotFoundException("Usuário não encontrad");

            return user;
        }

        public void UpdateUser(string userLogin, UpdateRequestModel userModel)
        {
            if (!_validation.ValidateUniqueEmail(userModel.Email))
                throw new Exception($"Já existe um usuário cadastrado com o email {userModel.Email}");
         
            var user = GetUserByLogin(userLogin);

            if (!string.IsNullOrEmpty(userModel.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);

            _mapper.Map(userModel, user);
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }

}

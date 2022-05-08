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
        private HelnivDbContext _context;
        private Validation _validation;
        private readonly IMapper _mapper;

        public UserService(HelnivDbContext context, IMapper mapper, Validation validation)
        {
            _context = context;
            _validation = validation;
            _mapper = mapper;
        }

        public void CreateUser(CreateRequestUserModel userModel)
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
                throw new KeyNotFoundException("Usuário não encontrado");

            return user;
        }

        public void UpdateUser(string userLogin, UpdateRequestUserModel userModel)
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

        public void DeleteUser(string userLogin)
        {
            var user = GetUserByLogin(userLogin);

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public bool UserLogin(LoginRequestModel userLogin)
        {
            var user = _context.Users.AsNoTracking().Where(x => x.Login == userLogin.Login.Trim()).FirstOrDefault();

            if (user == null)
                throw new KeyNotFoundException("Usuário não encontrado");

            var userpass = BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password);

            if (string.IsNullOrEmpty(userLogin.Password) || !userpass)
                throw new Exception("Senha Incorreta");

            return true;
        }
    }

}

using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Models;

namespace Helniv_AccessControl.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(CreateRequestUserModel userModel);

        public User GetUserByLogin(string userLogin);

        IEnumerable<User> GetAllUsers();

        public void UpdateUser(string userLogin, UpdateRequestUserModel userModel);

        public void DeleteUser(string userLogin);

        public AuthenticatedResponse UserLogin(LoginRequestModel userLogin);
    }
}

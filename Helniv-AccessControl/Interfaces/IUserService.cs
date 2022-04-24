using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Models;

namespace Helniv_AccessControl.Interfaces
{
    public interface IUserService
    {
        void CreateUser(CreateRequestModel userModel);

        public User GetUserByLogin(string userLogin);

        IEnumerable<User> GetAllUsers();

        public void UpdateUser(string userLogin, UpdateRequestModel userModel);
    }
}

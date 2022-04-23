using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Models;

namespace Helniv_AccessControl.Interfaces
{
    public interface IUserService
    {
        void CreateUser(CreateRequestModel userModel);

        IEnumerable<User> GetAllUsers();
    }
}

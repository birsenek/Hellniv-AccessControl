using Helniv_AccessControl.Utils;

namespace Helniv_AccessControl.Services
{
    public class ValidationService
    {
        private HelnivDbContext _userHelnivDbContext;

        public ValidationService(HelnivDbContext userHelnivDbContext)
        {
            _userHelnivDbContext = userHelnivDbContext;
        }

        public bool ValidateUniqueEmail(string userEmail)
        {
            if (_userHelnivDbContext.Users.Any(x => x.Email == userEmail))
                return false;

            return true;
        }
    }
}

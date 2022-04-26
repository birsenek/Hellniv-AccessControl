namespace Helniv_AccessControl.Utils
{
    public class Validation
    {
        private HelnivDbContext _userHelnivDbContext;

        public Validation(HelnivDbContext userHelnivDbContext)
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

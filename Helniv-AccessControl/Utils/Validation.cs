namespace Helniv_AccessControl.Utils
{
    public class Validation
    {
        private UserDbContext _userDbContext;

        public Validation(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public bool ValidateUniqueEmail(string userEmail)
        {
            if (_userDbContext.Users.Any(x => x.Email == userEmail))
                return false;

            return true;
        }
    }
}

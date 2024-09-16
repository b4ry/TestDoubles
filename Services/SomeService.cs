namespace Services
{
    public class SomeService : ISomeService
    {
        private readonly IUserService _userService;

        public SomeService(IUserService userService)
        {
            _userService = userService;
        }

        public bool SomeMethod(string user)
        {
            return _userService.AddUser(user);
        }

        public void SomeOtherMethod()
        {
        }

        public int YetAnotherMethod(string user)
        {
            var retrievedUser = _userService.GetUser(user);

            if(retrievedUser == null)
            {
                return 0;
            }

            return 100;
        }
    }
}

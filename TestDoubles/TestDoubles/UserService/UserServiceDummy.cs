using Services;

namespace ServiceTests.TestDoubles.UserService
{
    internal class UserServiceDummy : IUserService
    {
        public bool AddUser(string user)
        {
            throw new NotImplementedException();
        }

        public string? GetUser(string user)
        {
            throw new NotImplementedException();
        }
    }
}

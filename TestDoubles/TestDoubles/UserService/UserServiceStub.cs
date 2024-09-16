using Services;

namespace ServiceTests.TestDoubles.UserService
{
    internal class UserServiceStub : IUserService
    {
        public bool AddUser(string user)
        {
            return true;
        }

        public string? GetUser(string user)
        {
            return user;
        }
    }
}

using Services;

namespace ServiceTests.TestDoubles.UserService
{
    internal class UserServiceSpy : IUserService
    {
        public bool Called { get; set; }
        public string CallParameters { get; set; }

        public bool AddUser(string user)
        {
            Called = true;
            CallParameters = user;

            return true;
        }

        public string? GetUser(string user)
        {
            Called = true;
            CallParameters = user;

            return user;
        }
    }
}

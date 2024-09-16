using Services;

namespace ServiceTests.TestDoubles.UserService
{
    internal class UserServiceFake : IUserService
    {
        private readonly HashSet<string> _users = [];

        public bool AddUser(string user)
        {
            return _users.Add(user);
        }

        public string? GetUser(string user)
        {
            _users.TryGetValue(user, out string? retrievedUser);

            return retrievedUser;
        }
    }
}

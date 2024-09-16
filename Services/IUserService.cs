namespace Services
{
    public interface IUserService
    {
        public bool AddUser(string user);
        public string? GetUser(string user);
    }
}

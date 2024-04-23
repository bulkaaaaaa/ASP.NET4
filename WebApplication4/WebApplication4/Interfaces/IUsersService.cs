namespace WebApplication4.Interfaces
{
    public interface IUsersService
    {
        public string GetUserByID(int id);
        public string GetCurrentUser();
    }
}

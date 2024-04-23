using System.Text.Json;
using System.IO; 
using WebApplication4.Interfaces;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class UsersService : IUsersService
    {
        public string GetCurrentUser()
        {
            string jsonString = File.ReadAllText("currentUserInfo.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var user = JsonSerializer.Deserialize<UserInfo>(jsonString, options);

            return user.ToString();
        }

        public string GetUserByID(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("The ID must be equal to or greater than 0", nameof(id));
            }

            string filePath = "usersInfo.json";
            string jsonString = File.ReadAllText(filePath);

            Console.WriteLine($"Reading user data from file: {filePath}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var usersResponse = JsonSerializer.Deserialize<UsersResponse>(jsonString, options);

            foreach (var user in usersResponse.Users)
            {
                if (user.Id == id)
                {
                    return user.ToString();
                }
            }

            return GetCurrentUser();
        }
    }
}

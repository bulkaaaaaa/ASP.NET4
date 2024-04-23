using WebApplication4.Interfaces;
using WebApplication4.Services;

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IBooksService, BooksService>();
            builder.Services.AddSingleton<IUsersService, UsersService>();


            var app = builder.Build();

            app.Map("/", () => "Index Page");

            app.Map("/Library", () => "Welcome to the Library!");

            app.Map("/Library/Books", (IBooksService booksService) => $"Books:      \n{booksService.GetBooks()}");

            app.Map("/Library/Profile", (IUsersService usersService) => $"Info:     \n{usersService.GetCurrentUser()}");

            app.Map("/Library/Profile/{id}", (int id, IUsersService usersService) => $"{usersService.GetUserByID(id)}");
            /*app.Map("/Library/Profile/{id}", (string id, IUsersService usersService) => {
                if (int.TryParse(id, out int userId))
                {
                    return $"{usersService.GetUserByID(userId)}";
                }
                else
                {
                    return "Invalid user ID";
                }
            });
            */

            app.Run();
        }
    }
}
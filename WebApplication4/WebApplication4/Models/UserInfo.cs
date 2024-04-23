namespace WebApplication4.Models
{
    public class UserInfo
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";

        public override string ToString()
        {
            return $"ID: {Id};\nName: {Name};\nEmail: {Email}.\n";
        }
    }
}

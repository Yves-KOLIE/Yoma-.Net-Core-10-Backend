namespace YOMA.Models
{
    public class LoginModel
    {
        public required string email { get; set; }
        public required string password { get; set; }
        public string? confirmPassword { get; set; }
    }
}
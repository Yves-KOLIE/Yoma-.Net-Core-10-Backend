namespace YOMA.Models
{
    public class LoginCredentials
    {
        public required string email { get; set; }
        public required string password { get; set; }
        public string? confirmPassword { get; set; }
    }
    public class ForgotPasswordCredentials
    {
        public string? email { get; set; } = null;
        public string? code { get; set; } = null;
    }
    public class ResetPasswordCredentials
    {
        public required string email { get; set; }
        public required string code { get; set; }
        public required string newPassword { get; set; }
        public required string confirmPassword { get; set; }
    }
}
namespace PwiForms.Models
{
    public class PasswordReset
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
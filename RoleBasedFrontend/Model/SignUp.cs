using System.ComponentModel.DataAnnotations;

namespace RoleBased.Frontend.Model
{
    public class SignUp
    {
        [Key]
        public string RegNo { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DOB { get; set; } = DateTimeOffset.UtcNow;
        public string phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

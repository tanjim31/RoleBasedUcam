using System.ComponentModel.DataAnnotations;
namespace RoleBased.Frontend.Model
{
    public class LoginDB_f
    {
        [Key]
        [Required]
        public string RegNo { get; set; }
        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 6)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

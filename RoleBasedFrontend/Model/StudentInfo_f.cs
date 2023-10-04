using System.ComponentModel.DataAnnotations;
namespace RoleBased.Frontend.Model;

public class StudentInfo_f
{
    [Key]
    [Required]
    public string RegNo { get; set; }
    public string Name { get; set; }
    public DateTimeOffset DOB { get; set; } = DateTimeOffset.UtcNow;
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

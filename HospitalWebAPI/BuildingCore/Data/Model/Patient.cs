using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCore.Data.Model;

public class Patient
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string FullName { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}

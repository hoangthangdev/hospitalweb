using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCore.Data.Model;

public class DoctorInfo
{
    [MaxLength(100)]
    [Required]
    public string AcademicTitle { get; set; } = null!;
    [MaxLength(100)]
    [Required]
    public string PositionTitle { get; set; } = null!;

    [ForeignKey("UserId")]
    [Required]
    public User user {set; get; } = null!;
}

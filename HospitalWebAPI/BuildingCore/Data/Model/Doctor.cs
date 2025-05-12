using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCore.Data.Model
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string AcademicTitle { get; set; }
        [MaxLength(100)]
        [Required]
        public string PositionTitle { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}

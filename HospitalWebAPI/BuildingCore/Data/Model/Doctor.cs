using System.ComponentModel.DataAnnotations;

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
    }
}

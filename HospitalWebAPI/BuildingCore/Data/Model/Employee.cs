using BuildingCore.Data.Identity;
using System.ComponentModel.DataAnnotations;

namespace BuildingCore.Data.Model
{
    public class Employee
    {
        [Key]
        public required string DoctorId { get; set; }
        public string? SpecialtyId { get; set; }
        public virtual Specialties? Specialty { get; set; }
        public virtual ApplicationUser? User { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCore.Data.Model
{
    public class Patient
    {
        [Key, ForeignKey("User")]
        public required string PatientId { get; set; }
        public int MedicalExaminationNum { get; set; }
        public DateTime? LastExam { get; set; }

    }
}

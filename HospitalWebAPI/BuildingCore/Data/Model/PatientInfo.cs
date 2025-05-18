using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCore.Data.Model;

public class PatientInfo
{
    public int Id { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
}

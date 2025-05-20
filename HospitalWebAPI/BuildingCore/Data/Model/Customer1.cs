using BuildingCore.Interfaces;

namespace BuildingCore.Data.Model;
public class CustomerModel : IEntity, IHasTrace, IHasIsDeleted
{
    public required string Name { get; set; }
    public bool IsDeleted { get; set; }
    public long? CreatedBy { get; set; }
    public string? CreateByName { get; set; }
    public long? ModifiedBy { get; set; }
    public string? ModifyByName { get; set; }
}

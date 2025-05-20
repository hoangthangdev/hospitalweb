using BuildingCore.Interfaces;

namespace BuildingCore.Data.Model
{
    public class Specialties : IEntity, IHasTrace, IHasIsDeleted
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
        long? IHasTrace.CreatedBy { get; set; }
        string? IHasTrace.CreateByName { get; set; }
        long? IHasTrace.ModifiedBy { get; set; }
        string? IHasTrace.ModifyByName { get; set; }
    }
}

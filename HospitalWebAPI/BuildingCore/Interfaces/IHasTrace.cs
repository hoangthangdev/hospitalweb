namespace BuildingCore.Interfaces
{
    public interface IHasTrace
    {
        public long? CreatedBy { get; set; }
        public string? CreateByName { get; set; }
        public long? ModifiedBy { get; set; }
        public string? ModifyByName { get; set; }
    }
}

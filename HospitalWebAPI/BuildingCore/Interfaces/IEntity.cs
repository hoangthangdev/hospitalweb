namespace BuildingCore.Interfaces
{
    public class IEntity
    {
        public required string Id { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? ModifyTime { get; set; }
        public required byte[] Version { get; set; }
    }
}

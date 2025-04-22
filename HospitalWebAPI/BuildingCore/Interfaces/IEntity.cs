namespace BuildingCore.Interfaces
{
    public class IEntity
    {
        public long Id { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? ModifyTime { get; set; }
        public byte[] Version { get; set; }
    }
}

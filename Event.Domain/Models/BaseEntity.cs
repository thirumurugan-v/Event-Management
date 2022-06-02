namespace Event.Domain.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public int CreatedById { get; set; }
        public DateTimeOffset ModifiedDateTime { get; set; }
        public int ModifiedById { get; set; }
    }
}

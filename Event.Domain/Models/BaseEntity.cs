namespace Event.Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid IsActive { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public int CreatedById { get; set; }
        public DateTimeOffset ModifiedDateTime { get; set; }
        public int ModifiedById { get; set; }
    }
}

namespace Event.Domain.Models
{
    public class EventList : BaseEntity
    {
        public string EventName { get; set; } = string.Empty;
        public DateTimeOffset StartTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public int GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string ThumbnailImagePath { get; set; } = string.Empty;
        public int NoOfPeopleGoing { get; set; }
        public bool IsOnlineEvent { get; set; }
    }
}

namespace Event.API.DTOs.Event
{
    public class EventSearchDto
    {
        public int Skip { get; private set; }
        public int Take { get; private set; }
        public string City { get; private set; } = string.Empty;
        public bool IsOnline { get; private set; }
        public DateTimeOffset StartTime { get; private set; }
    }
}

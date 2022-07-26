namespace Event.API.DTOs.Event
{
    public class EventDto
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string GroupName { get; private set; } = string.Empty;
        public DateTimeOffset StartTime { get; private set; }
        public bool IsOnlineEvent { get; private set; }
        public int NoOfPeopleGoing { get; private set; }
        public string ThumbnailImagePath { get; private set; } = string.Empty;
        public string LocationName { get; private set; } = string.Empty;

        public static EventDto MapToDto(Domain.Models.EventAggregate.Event eventEntity)
        {
            return new EventDto()
            {
                Id = eventEntity.Id,
                Name = eventEntity.Name,
                GroupName = eventEntity.GroupName,
                StartTime = eventEntity.StartTime,
                IsOnlineEvent = eventEntity.IsOnlineEvent,
                NoOfPeopleGoing = eventEntity.NoOfPeopleGoing,
                ThumbnailImagePath = eventEntity.ThumbnailImagePath,
                LocationName = eventEntity.Location.Name
            };
        }
    }

    public class EventSearchResult
    {
        public List<EventDto> Events { get; set; } = new List<EventDto>();
    }
}

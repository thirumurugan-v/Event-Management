using Event.Domain.Models.Common;
using Event.Domain.Models.Common.Interface;

namespace Event.Domain.Models.EventAggregate
{
    public class Event : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = string.Empty;
        public int GroupId { get; private set; }
        public string GroupName { get; private set; } = string.Empty;
        public DateTimeOffset StartTime { get; private set; }
        public DateTimeOffset EndTime { get; private set; }
        public int TotalCapacity { get; private set; }
        public bool IsOnlineEvent { get; private set; }
        public string? OnlineEventUrl { get; private set; } = string.Empty;
        public int NoOfPeopleGoing { get; private set; }
        public bool IsCancelled { get; private set; }
        public string? ThumbnailImagePath { get; private set; } = string.Empty;
        public Location Location { get; private set; }

        private readonly List<EventParticipant> _participants;
        public IReadOnlyCollection<EventParticipant> Participants => _participants;
    }
}

using Event.Domain.Models.Common;

namespace Event.Domain.Models.EventAggregate
{
    public class EventParticipant : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public int EventId { get; private set; }
        public ParticipationStatus ParticipationStatus { get; private set; }
    }
}

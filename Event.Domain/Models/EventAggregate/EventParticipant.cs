namespace Event.Domain.Models.EventAggregate
{
    public class EventParticipant : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int EventId { get; set; }
        public ParticipationStatus ParticipationStatus { get; private set; }
    }
}

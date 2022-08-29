using Event.Domain.Models.Common;
using Event.Domain.Models.Common.Interface;

namespace Event.Domain.Models.GroupAggregate
{
    public class Group : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int LocationId { get; private set; }
        public string? ThumbnailImagePath { get; private set; } = string.Empty;


        private readonly List<GroupCategory> _categories;
        public IReadOnlyCollection<GroupCategory> Categories => _categories;

        private readonly List<GroupMember> _members;
        public IReadOnlyCollection<GroupMember> Members => _members;

        private readonly List<EventAggregate.Event> _events;
        public IReadOnlyCollection<EventAggregate.Event> Events => _events;
    }
}

using Event.Domain.Models.Common;

namespace Event.Domain.Models.GroupAggregate
{
    public class GroupMember : BaseEntity
    {
        public int UserId { get; private set; }
        public int GroupId { get; private set; }
        // Represents the user's first name plus last name
        public string Name { get; private set; } = string.Empty;
        public DateTimeOffset DateJoined { get; private set; }
        public MembershipStatus MembershipStatus { get; private set; }
    }
}

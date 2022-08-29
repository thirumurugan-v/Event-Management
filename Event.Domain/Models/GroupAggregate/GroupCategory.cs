using Event.Domain.Models.Common;

namespace Event.Domain.Models.GroupAggregate
{
    public class GroupCategory : BaseEntity
    {
        public int CategoryId { get; private set; }
        public int GroupId { get; private set; }
    }
}

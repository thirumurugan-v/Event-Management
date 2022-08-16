using Event.Domain.Common;

namespace Event.Domain.Models.Master.Category
{
    public class Category : MasterBaseEntity
    {
        public string Name { get; private set; } = string.Empty;
    }
}

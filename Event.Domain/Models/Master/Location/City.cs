using Event.Domain.Common;

namespace Event.Domain.Models.Master.Location
{
    public class City : MasterBaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Country { get; private set; } = string.Empty;
        public string DisplayName { get; private set; } = string.Empty;
        public string CountryCode { get; private set; } = string.Empty;
    }
}

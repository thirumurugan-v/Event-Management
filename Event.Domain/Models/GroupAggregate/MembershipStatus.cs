using Event.Domain.Exceptions;
using Event.Domain.Models.Common;

namespace Event.Domain.Models.GroupAggregate
{
    public class MembershipStatus : Enumeration
    {
        public static MembershipStatus Administrator = new(1, nameof(Administrator).ToLowerInvariant());
        public static MembershipStatus RegularMember = new(2, nameof(RegularMember).ToLowerInvariant());
        public static MembershipStatus PremiumMember = new(3, nameof(PremiumMember).ToLowerInvariant());

        public MembershipStatus(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<MembershipStatus> List() => new[] { Administrator, RegularMember, PremiumMember };


        public static MembershipStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new MembershipStatusException($"Possible values for MembershipStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static MembershipStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new MembershipStatusException($"Possible values for MembershipStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}

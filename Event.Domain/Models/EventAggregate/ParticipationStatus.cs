using Event.Domain.Exceptions;
using Event.Domain.Models.Common;

namespace Event.Domain.Models.EventAggregate
{
    public class ParticipationStatus : Enumeration
    {
        public static ParticipationStatus Hosting = new(1, nameof(Hosting).ToLowerInvariant());
        public static ParticipationStatus Going = new(2, nameof(Going).ToLowerInvariant());
        public static ParticipationStatus NotGoing = new(3, nameof(NotGoing).ToLowerInvariant());
        public static ParticipationStatus Waiting = new(4, nameof(Waiting).ToLowerInvariant());

        public ParticipationStatus(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<ParticipationStatus> List() =>
        new[] { Going, NotGoing, Waiting, Hosting };


        public static ParticipationStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new ParticipationStatusException($"Possible values for ParticipationStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static ParticipationStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ParticipationStatusException($"Possible values for ParticipationStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

    }
}

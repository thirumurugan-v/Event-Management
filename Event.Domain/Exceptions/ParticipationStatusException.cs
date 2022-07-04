namespace Event.Domain.Exceptions
{
    public class ParticipationStatusException : Exception
    {
        public ParticipationStatusException()
        { }

        public ParticipationStatusException(string message)
            : base(message)
        { }

        public ParticipationStatusException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

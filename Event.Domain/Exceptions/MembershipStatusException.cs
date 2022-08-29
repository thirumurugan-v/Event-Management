namespace Event.Domain.Exceptions
{
    public class MembershipStatusException : Exception
    {
        public MembershipStatusException()
        { }

        public MembershipStatusException(string message)
            : base(message)
        { }

        public MembershipStatusException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

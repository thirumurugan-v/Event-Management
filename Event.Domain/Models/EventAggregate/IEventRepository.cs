namespace Event.Domain.Models.EventAggregate
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<List<Event>> GetEventsAsync(string city, int skip, int take);
    }
}

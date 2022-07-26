using Event.API.DTOs.Event;

namespace Event.API.Services.Interface
{
    public interface IEventService
    {
        Task<EventSearchResult> GetEvents(string city);
    }
}

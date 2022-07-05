using Event.API.DTOs.Event;

namespace Event.API.Services.Interface
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEvents(string city);
    }
}

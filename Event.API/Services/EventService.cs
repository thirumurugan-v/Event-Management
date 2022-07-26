using Event.API.DTOs.Event;
using Event.API.Services.Interface;
using Event.Domain.Models.Common.Interface;

namespace Event.API.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventSearchResult> GetEvents(string city)
        {
            var result = new EventSearchResult();

            var events = await _unitOfWork.EventRepository.GetEventsAsync(city ?? "Stockholm", 0, 20);

            foreach(var item in events)
            {
                result.Events.Add(EventDto.MapToDto(item));
            }

            return result;
        }
    }
}

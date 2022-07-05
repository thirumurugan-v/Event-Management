using Event.API.DTOs.Event;
using Event.API.Services.Interface;
using Event.Domain.Models;

namespace Event.API.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventDto>> GetEvents(string city)
        {
            var result = new List<EventDto>();

            var events = await _unitOfWork.EventRepository.GetEventsAsync(city ?? "Stockholm", 0, 20);

            foreach(var item in events)
            {
                result.Add(EventDto.MapToDto(item));
            }

            return result;
        }
    }
}

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

        public async Task<EventSearchResult> GetEvents(EventSearchRequest searchRequest)
        {
            var result = new EventSearchResult();
            var startDateTime = DateTime.Now.AddHours(2);
            var endDateTime = DateTime.Now.AddDays(14);

            if(searchRequest.DateId == 1) { }

            _unitOfWork.EventRepository.SetFilters(searchRequest.Keyword, searchRequest.LocationId, startDateTime, endDateTime, searchRequest.TypeId, searchRequest.CategoryId);

            var events = await _unitOfWork.EventRepository.GetEventsAsync(0, 20);

            foreach(var item in events)
            {
                result.Events.Add(EventDto.MapToDto(item));
            }

            return result;
        }
    }
}

using Event.API.DTOs.Event;
using Event.API.Services.Interface;
using Event.Domain.Models.Common.Interface;
using System.Globalization;

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
            DateTime startDateTime, endDateTime;

            GetDateRangeFilter(searchRequest, out startDateTime, out endDateTime);

            _unitOfWork.EventRepository.SetFilters(searchRequest.Keyword, searchRequest.LocationId, startDateTime, endDateTime, searchRequest.TypeId, searchRequest.CategoryId);

            var events = await _unitOfWork.EventRepository.GetEventsAsync(0, 20);

            foreach (var item in events)
            {
                result.Events.Add(EventDto.MapToDto(item));
            }

            return result;
        }

        private static void GetDateRangeFilter(EventSearchRequest searchRequest, out DateTime startDateTime, out DateTime endDateTime)
        {
            startDateTime = DateTime.Now.AddHours(2);
            endDateTime = DateTime.Now.AddDays(14);

            switch (searchRequest.DateId)
            {
                case 1:
                    startDateTime = DateTime.Now.AddHours(1);
                    endDateTime = DateTime.Now.AddHours(13);
                    break;
                case 2:
                    startDateTime = DateTime.Now.AddHours(1);
                    endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);
                    break;
                case 3:
                    startDateTime = DateTime.Today.AddDays(1);
                    endDateTime = DateTime.Today.AddDays(2).AddTicks(-1);
                    break;
                case 4:
                    startDateTime = DateTime.Now.AddHours(1);
                    endDateTime = LastDayOfWeek(DateTime.Today).AddDays(1).AddTicks(-1);
                    break;
                case 5:
                    startDateTime = LastDayOfWeek(DateTime.Today);
                    endDateTime = LastDayOfWeek(DateTime.Today).AddDays(2).AddTicks(-1);
                    break;
                case 6:
                    startDateTime = FirstDayOfWeek(DateTime.Today.AddDays(7));
                    endDateTime = LastDayOfWeek(DateTime.Today.AddDays(7)).AddDays(1).AddTicks(-1);
                    break;
            }
        }

        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }
    }
}

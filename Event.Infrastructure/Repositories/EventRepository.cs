using Event.Domain.Models.Common.Interface;
using Event.Domain.Models.EventAggregate;
using Event.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Event.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _context;
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public string SearchKey { get; set; }
        public int LocationId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }

        public EventRepository(EventContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public Task<List<Domain.Models.EventAggregate.Event>> GetEventsAsync(int skip, int take)
        {
            var events = _context.Events.Where(x => (string.IsNullOrEmpty(SearchKey) || (x.Name.Contains(SearchKey) || x.Description.Contains(SearchKey)))
                && (LocationId == 0 || x.Location.LocationId == LocationId)
                && x.StartTime > StartDateTime
                && x.EndTime < EndDateTime
                && (TypeId == 0 || x.IsOnlineEvent == (TypeId == 1)))
                .OrderBy(x => x.StartTime);

            return events.ToListAsync(); 
        }

        public void SetFilters(string searchKey, int locationId, DateTime startDateTime, DateTime endDateTime, int typeId, int categoryId)
        {
            this.SearchKey = searchKey;
            this.LocationId = locationId;
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
            this.TypeId = typeId;
            this.CategoryId = categoryId;
        }
    }
}

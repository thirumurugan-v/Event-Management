using Event.Domain.Models;
using Event.Domain.Models.EventAggregate;
using Event.Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Event.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _context;
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public EventRepository(EventContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public Task<List<Domain.Models.EventAggregate.Event>> GetEventsAsync(string city, int skip, int take)
        {
            var events = _context.Events.Where(x => x.Location.City == city)
                .OrderBy(x => x.CreatedDateTime);

            return events.ToListAsync();
        }
    }
}

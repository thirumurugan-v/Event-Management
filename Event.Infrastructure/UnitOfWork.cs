using Event.Domain.Models;
using Event.Domain.Models.EventAggregate;
using Event.Infrastructure.Context;

namespace Event.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEventRepository EventRepository { get; set; }

        private readonly EventContext _eventContext;

        public UnitOfWork(EventContext eventContext, IEventRepository eventRepository)
        {
            _eventContext = eventContext;
            EventRepository = eventRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _eventContext.SaveChangesAsync(cancellationToken);

        public void Dispose() => _eventContext.Dispose();

    }
}

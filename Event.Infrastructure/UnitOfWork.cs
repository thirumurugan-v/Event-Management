using Event.Domain.Models;
using Event.Domain.Models.Common.Interface;
using Event.Domain.Models.EventAggregate;
using Event.Domain.Models.Master.Location;
using Event.Infrastructure.Context;

namespace Event.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEventRepository EventRepository { get; set; }
        public ICityRepository CityRepository { get; set; }

        private readonly EventContext _eventContext;

        public UnitOfWork(EventContext eventContext, IEventRepository eventRepository, ICityRepository cityRepository)
        {
            _eventContext = eventContext;
            EventRepository = eventRepository;
            CityRepository = cityRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _eventContext.SaveChangesAsync(cancellationToken);

        public void Dispose() => _eventContext.Dispose();

    }
}

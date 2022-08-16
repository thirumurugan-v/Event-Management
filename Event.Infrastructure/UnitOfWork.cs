using Event.Domain.Models;
using Event.Domain.Models.Common.Interface;
using Event.Domain.Models.EventAggregate;
using Event.Domain.Models.Master.Category;
using Event.Domain.Models.Master.Location;
using Event.Infrastructure.Context;

namespace Event.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEventRepository EventRepository { get; set; }
        public ICityRepository CityRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }

        private readonly EventContext _eventContext;

        public UnitOfWork(EventContext eventContext, IEventRepository eventRepository, ICityRepository cityRepository,
            ICategoryRepository categoryRepository)
        {
            _eventContext = eventContext;
            EventRepository = eventRepository;
            CityRepository = cityRepository;
            CategoryRepository = categoryRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _eventContext.SaveChangesAsync(cancellationToken);

        public void Dispose() => _eventContext.Dispose();

    }
}

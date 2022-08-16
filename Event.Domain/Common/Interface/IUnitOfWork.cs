using Event.Domain.Models.EventAggregate;
using Event.Domain.Models.Master.Category;
using Event.Domain.Models.Master.Location;

namespace Event.Domain.Models.Common.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository EventRepository { get; set; }
        ICityRepository CityRepository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

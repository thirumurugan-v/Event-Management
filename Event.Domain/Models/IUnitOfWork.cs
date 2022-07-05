using Event.Domain.Models.EventAggregate;

namespace Event.Domain.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository EventRepository { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

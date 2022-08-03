using Event.Domain.Models.Common.Interface;

namespace Event.Domain.Models.EventAggregate
{
    public interface IEventRepository : IRepository<Event>
    {
        string SearchKey { get; set; }
        int LocationId { get; set; }
        DateTime StartDateTime { get; set; }
        DateTime EndDateTime { get; set; }
        int TypeId { get; set; }
        int CategoryId { get; set; }
        Task<List<Event>> GetEventsAsync(int skip, int take);
        void SetFilters(string searchKey, int locationId, DateTime startDateTime, DateTime endDateTime, int typeId, int categoryId);
    }
}

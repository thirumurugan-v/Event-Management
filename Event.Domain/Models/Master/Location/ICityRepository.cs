namespace Event.Domain.Models.Master.Location
{
    public interface ICityRepository
    {
        Task<List<City>> GetLocationsAsync(string searchKey, int maxCount);
    }
}

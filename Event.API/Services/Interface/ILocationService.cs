using Event.API.DTOs.Location;

namespace Event.API.Services.Interface
{
    public interface ILocationService
    {
        Task<LocationResult> GetLocations(string searchKey);
    }
}

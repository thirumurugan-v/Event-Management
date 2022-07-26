using Event.API.DTOs.Location;
using Event.API.Services.Interface;
using Event.Domain.Models.Common.Interface;

namespace Event.API.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LocationResult> GetLocations(string searchKey)
        {
            var result = new LocationResult();

            var locations = await _unitOfWork.CityRepository.GetLocationsAsync(searchKey, 10);

            foreach (var item in locations)
            {
                result.Locations.Add(LocationDto.MapToDto(item));
            }

            return result;
        }
    }
}

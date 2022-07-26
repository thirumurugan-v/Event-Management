using Event.Domain.Models.Master.Location;

namespace Event.API.DTOs.Location
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;

        public static LocationDto MapToDto(City cityEntity)
        {
            return new LocationDto()
            {
                Id = cityEntity.Id,
                Location = cityEntity.DisplayName,
            };
        }
    }
    
    public class LocationResult
    {
        public List<LocationDto> Locations { get; set; } = new List<LocationDto>();
    }
}

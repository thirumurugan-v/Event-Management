using Event.API.DTOs.Location;
using Event.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Event.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }


        /// <summary>
        /// Gets the locations based on the search keyword
        /// </summary>
        /// <param name="searchText">search keyword entered by the user</param>
        /// <returns></returns>
        [Route("Get")]
        [HttpGet]
        [ProducesResponseType(typeof(LocationDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<LocationDto>> GetLocationsAsync(string searchText)
        {
            try
            {
                var locations = await _locationService.GetLocations(searchText);

                return Ok(locations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

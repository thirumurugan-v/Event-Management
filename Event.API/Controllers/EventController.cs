using Event.API.DTOs.Event;
using Event.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Event.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Gets all the events happening in the given city.
        /// </summary>
        /// <param name="city">Filter by the city</param>
        /// <returns></returns>
        [Route("GetEvents")]
        [HttpPost]
        [ProducesResponseType(typeof(EventSearchResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<EventSearchResult>> GetEventsAsync(EventSearchRequest searchRequest)
        {
            try
            {
                var events = await _eventService.GetEvents(searchRequest);

                return Ok(events);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

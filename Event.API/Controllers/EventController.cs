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
        [HttpGet]
        [ProducesResponseType(typeof(EventSearchResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EventSearchResult>> GetEventsAsync(string city)
        {
            var events = await _eventService.GetEvents(city);

            return Ok(events);
        }
    }
}

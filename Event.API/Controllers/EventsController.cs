using Event.API.DTOs.Event;
using Event.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Event.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Route("GetEvents")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsAsync(string city)
        {
            var events = await _eventService.GetEvents(city);

            return Ok(events);
        }
    }
}

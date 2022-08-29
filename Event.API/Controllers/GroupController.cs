using Event.API.DTOs.Group;
using Event.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Event.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [Route("Create")]
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<string>> CreateGroup(GroupDto groupDto)
        {
            try
            {
                var result = await _groupService.CreateGroup(groupDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

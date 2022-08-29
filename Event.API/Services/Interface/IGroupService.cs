using Event.API.DTOs.Group;

namespace Event.API.Services.Interface
{
    public interface IGroupService
    {
        Task<string> CreateGroup(GroupDto groupDto);
    }
}

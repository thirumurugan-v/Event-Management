using Event.API.DTOs.Category;

namespace Event.API.Services.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategories();
    }
}

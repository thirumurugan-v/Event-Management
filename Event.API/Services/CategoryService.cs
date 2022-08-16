using Event.API.DTOs.Category;
using Event.API.Services.Interface;
using Event.Domain.Models.Common.Interface;

namespace Event.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var result = new List<CategoryDto>();

            var categories = await _unitOfWork.CategoryRepository.GetCategoriesAsync();

            foreach (var item in categories)
            {
                result.Add(CategoryDto.MapToDto(item));
            }

            return result;
        }
    }
}

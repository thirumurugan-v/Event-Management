namespace Event.API.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public static CategoryDto MapToDto(Domain.Models.Master.Category.Category category)
        {
            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}

namespace Event.Domain.Models.Master.Category
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}

using Event.Domain.Models.Common.Interface;
using Event.Domain.Models.Master.Category;
using Event.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Event.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EventContext _context;
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public CategoryRepository(EventContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<List<Category>> GetCategoriesAsync()
        {
            var categories = _context.Categories.Where(x => x.IsActive)
                .OrderBy(x => x.Id);

            return categories.ToListAsync();
        }
    }
}

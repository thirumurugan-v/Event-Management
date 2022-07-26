using Event.Domain.Models.Common.Interface;
using Event.Domain.Models.Master.Location;
using Event.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly EventContext _context;
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public CityRepository(EventContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<City>> GetLocationsAsync(string searchKey, int maxCount)
        {
            var locations = _context.Cities.Where(x => x.DisplayName.Contains(searchKey))
                .OrderBy(x => x.DisplayName).Take(maxCount);

            return locations.ToListAsync();
        }
    }
}

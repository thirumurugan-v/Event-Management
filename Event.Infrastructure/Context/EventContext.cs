using Event.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Event.Domain.Models;

namespace Event.Infrastructure.Context
{
    public class EventContext : DbContext
    {
        public DbSet<EventList> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
        }

        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }
    }
}

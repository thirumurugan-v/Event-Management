using Event.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Event.Domain.Models.EventAggregate;
using Event.Domain.Models.Master.Location;
using Event.Infrastructure.EntityConfigurations.Master;
using Event.Domain.Models.Master.Category;

namespace Event.Infrastructure.Context
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }

        public DbSet<Domain.Models.EventAggregate.Event> Events { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<ParticipationStatus> ParticipationStatus { get; set; }

        // Master tables
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EventParticipantEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipationStatusEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());

            modelBuilder.Entity<Domain.Models.EventAggregate.Event>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<EventParticipant>().Property(x => x.Id).UseIdentityColumn();
        }
    }
}

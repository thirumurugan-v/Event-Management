using Microsoft.EntityFrameworkCore;
using Event.Domain.Models.EventAggregate;
using Event.Domain.Models.Master.Location;
using Event.Infrastructure.EntityConfigurations.Master;
using Event.Domain.Models.Master.Category;
using Event.Infrastructure.EntityConfigurations.Event;
using Event.Domain.Models.GroupAggregate;
using Event.Infrastructure.EntityConfigurations.Group;

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
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupCategory> GroupCategories { get; set; }
        public DbSet<MembershipStatus> MembershipStatus { get; set; }

        // Master tables
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EventParticipantEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipationStatusEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new GroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupCategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupMemberEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MembershipStatusEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());

            modelBuilder.Entity<Domain.Models.EventAggregate.Event>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<EventParticipant>().Property(x => x.Id).UseIdentityColumn();

            modelBuilder.Entity<Group>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<GroupMember>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<GroupCategory>().Property(x => x.Id).UseIdentityColumn();
        }
    }
}

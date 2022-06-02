using Event.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infrastructure.EntityConfigurations
{
    class EventEntityTypeConfiguration : IEntityTypeConfiguration<EventList>
    {
        public void Configure(EntityTypeBuilder<EventList> configuration)
        {
            configuration.HasKey(x => x.Id);

            configuration.Property(x => x.EventName)
                .IsRequired()
                .HasMaxLength(100);

            configuration.Property(x => x.StartTime)
                .IsRequired();

            configuration.Property(x => x.Location)
                .IsRequired()
                .HasMaxLength(200);

            configuration.Property(x => x.GroupId)
                .IsRequired();

            configuration.Property(x => x.GroupName)
                .IsRequired()
                .HasMaxLength(100);

            configuration.Property(x => x.ThumbnailImagePath)
                .IsRequired()
                .HasMaxLength(200);

            configuration.Property(x => x.NoOfPeopleGoing)
                .IsRequired()
                .HasMaxLength(1000);

            configuration.Property(x => x.IsOnlineEvent)
                .IsRequired();
        }
    }
}

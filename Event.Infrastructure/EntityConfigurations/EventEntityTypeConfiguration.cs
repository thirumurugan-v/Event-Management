using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infrastructure.EntityConfigurations
{
    class EventEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.EventAggregate.Event>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.EventAggregate.Event> configuration)
        {
            configuration.HasKey(x => x.Id);

            configuration.Property(o => o.Id)
                .UseHiLo("eventseq");

            configuration.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            configuration.Property(x => x.GroupId)
                .IsRequired();

            configuration.Property(x => x.StartTime)
                .IsRequired();

            configuration.Property(x => x.EndTime)
                .IsRequired();

            configuration.Property(x => x.TotalCapacity)
                .IsRequired();

            configuration.Property(x => x.IsOnlineEvent)
                .IsRequired()
                .HasMaxLength(10000);

            configuration.Property(x => x.NoOfPeopleGoing)
                .IsRequired()
                .HasMaxLength(1000);

            configuration.Property(x => x.IsCancelled)
                .IsRequired();

            configuration.Property(x => x.ThumbnailImagePath)
                .HasMaxLength(200);

            configuration
            .OwnsOne(o => o.Location, a =>
            {
                a.Property<int>("EventId")
                .UseHiLo("eventseq").UseIdentityColumn();
                //a.OwnsOne(x => x.ZipCode, x => { x.Property<int>("EventAddressId").UseHiLo("seq"); }).WithOwner();
                a.WithOwner();
            });

            var navigation = configuration.Metadata.FindNavigation(nameof(Domain.Models.EventAggregate.Event.Participants));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}

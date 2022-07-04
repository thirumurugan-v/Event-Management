using Event.Domain.Models.EventAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infrastructure.EntityConfigurations
{
    public class EventParticipantEntityTypeConfiguration : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> configuration)
        {
            configuration.HasKey(x => x.Id);

            configuration.Property(o => o.Id)
                .UseHiLo("eventparticipationseq");

            configuration.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            configuration.Property(x => x.EventId)
                .IsRequired();

            configuration
                .Property<int>("_participationStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ParticipationStatusId")
                .IsRequired();

            configuration
                .HasOne(o => o.ParticipationStatus)
                .WithMany()
                .HasForeignKey("ParticipationStatusId");
        }
    }
}

using Event.Domain.Models.EventAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infrastructure.EntityConfigurations.Master
{
    public class ParticipationStatusEntityTypeConfiguration : IEntityTypeConfiguration<ParticipationStatus>
    {
        public void Configure(EntityTypeBuilder<ParticipationStatus> configuration)
        {
            configuration.HasKey(o => o.Id);

            configuration.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            configuration.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

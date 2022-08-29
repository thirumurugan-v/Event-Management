using Event.Domain.Models.GroupAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infrastructure.EntityConfigurations.Master
{
    public class MembershipStatusEntityTypeConfiguration : IEntityTypeConfiguration<MembershipStatus>
    {
        public void Configure(EntityTypeBuilder<MembershipStatus> configuration)
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

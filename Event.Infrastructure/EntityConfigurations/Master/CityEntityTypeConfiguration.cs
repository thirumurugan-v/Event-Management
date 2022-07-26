using Event.Domain.Models.Master.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infrastructure.EntityConfigurations.Master
{
    public class CityEntityTypeConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> configuration)
        {
            configuration.HasKey(x => x.Id);

            configuration.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            configuration.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(100);

            configuration.Property(x => x.DisplayName)
                .IsRequired()
                .HasMaxLength(200);

            configuration.Property(x => x.CountryCode)
                .IsRequired()
                .HasMaxLength(2);
        }
    }
}

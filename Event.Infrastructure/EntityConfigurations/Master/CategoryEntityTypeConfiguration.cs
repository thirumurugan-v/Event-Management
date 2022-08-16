using Event.Domain.Models.Master.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infrastructure.EntityConfigurations.Master
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> configuration)
        {
            configuration.HasKey(x => x.Id);

            configuration.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}

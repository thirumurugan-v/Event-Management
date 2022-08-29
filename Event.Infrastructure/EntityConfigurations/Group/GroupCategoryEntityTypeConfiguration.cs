using Event.Domain.Models.GroupAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infrastructure.EntityConfigurations.Group
{
    public class GroupCategoryEntityTypeConfiguration : IEntityTypeConfiguration<GroupCategory>
    {
        public void Configure(EntityTypeBuilder<GroupCategory> configuration)
        {
            configuration.HasKey(x => x.Id);

            configuration.Property(o => o.Id)
                .UseHiLo("groupcategoryseq");

            configuration.Property(x => x.GroupId)
                .IsRequired();

            configuration.Property(x => x.CategoryId)
                .IsRequired();
        }
    }
}

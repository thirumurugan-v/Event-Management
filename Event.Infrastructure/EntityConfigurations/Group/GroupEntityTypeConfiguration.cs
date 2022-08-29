using Event.Domain.Models.GroupAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infrastructure.EntityConfigurations.Group
{
    public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.GroupAggregate.Group>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.GroupAggregate.Group> configuration)
        {
            configuration.HasKey(x => x.Id);

            configuration.Property(o => o.Id)
                .UseHiLo("groupseq");

            configuration.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            configuration.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(4000);

            configuration.Property(x => x.LocationId)
                .IsRequired();

            configuration.Property(x => x.ThumbnailImagePath)
                .HasMaxLength(200);

            var groupCategoryNavigation = configuration.Metadata.FindNavigation(nameof(Domain.Models.GroupAggregate.Group.Categories));
            groupCategoryNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var groupMembersNavigation = configuration.Metadata.FindNavigation(nameof(Domain.Models.GroupAggregate.Group.Members));
            groupMembersNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var eventMembersNavigation = configuration.Metadata.FindNavigation(nameof(Domain.Models.GroupAggregate.Group.Events));
            eventMembersNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}

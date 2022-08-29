using Event.Domain.Models.GroupAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infrastructure.EntityConfigurations.Group
{
    public class GroupMemberEntityTypeConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> configuration)
        {
            configuration.HasKey(x => x.Id);

            configuration.Property(o => o.Id)
                .UseHiLo("groupmemberseq");

            configuration.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            configuration.Property(x => x.GroupId)
                .IsRequired();

            configuration.Property(x => x.UserId)
                .IsRequired();

            configuration.Property(x => x.DateJoined)
                .IsRequired();

            configuration
                .HasOne(o => o.MembershipStatus)
                .WithMany()
                .HasForeignKey("MembershipStatusId");
        }
    }
}

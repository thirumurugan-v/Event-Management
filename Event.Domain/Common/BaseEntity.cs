using System.ComponentModel.DataAnnotations.Schema;

namespace Event.Domain.Models.Common
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public int CreatedById { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public int? ModifiedById { get; set; }
    }
}

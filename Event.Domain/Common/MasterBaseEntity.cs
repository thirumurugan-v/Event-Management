using System.ComponentModel.DataAnnotations.Schema;

namespace Event.Domain.Common
{
    public class MasterBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}

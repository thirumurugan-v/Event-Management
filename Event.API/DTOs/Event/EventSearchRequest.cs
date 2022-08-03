using System.ComponentModel.DataAnnotations;

namespace Event.API.DTOs.Event
{
    public class EventSearchRequest
    {
        [MaxLength(20)]
        public string Keyword { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public int DateId { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
    }
}

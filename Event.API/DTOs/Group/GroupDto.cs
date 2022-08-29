namespace Event.API.DTOs.Group
{
    public class GroupDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int[] Category { get; set; } = Array.Empty<int>();
        public int LocationId { get; set; }

    }
}

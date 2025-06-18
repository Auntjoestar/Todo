using Todo.Models;

namespace Todo.DTOs.Activity
{
    public class CreateActivityDto
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Status { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public enum Status
    {
        Active,
        Inactive,
        OnHold,
    }

    public class Activity
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(500)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public required Status Status { get; set; }

        public required string UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
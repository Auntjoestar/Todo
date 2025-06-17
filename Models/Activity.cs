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
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public Status Status { get; set; }

        // public int UserId { get; set; }
    }
}
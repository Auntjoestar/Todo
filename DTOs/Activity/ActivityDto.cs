using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.DTOs.Activity
{
    public class ActivityDto
    {
        public int ID { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Status { get; set; }

        public required string UserId { get; set; }
    }
}
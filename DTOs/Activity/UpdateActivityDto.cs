using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.DTOs.Activity
{
    public class UpdateActivityDto
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Status { get; set; }
    }
}
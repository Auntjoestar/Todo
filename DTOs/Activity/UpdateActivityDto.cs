using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.DTOs.Activity
{
    public class UpdateActivityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
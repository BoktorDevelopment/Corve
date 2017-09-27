using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.Models
{
    public class ScheduleTaskViewModel
    {
        public int Id { get; set; }
        public int Week { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string User { get; set; }
    }
}

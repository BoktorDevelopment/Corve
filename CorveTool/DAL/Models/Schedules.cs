using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CorveTool.DAL.Models
{
    public class Schedules : IDb
    {
        [Key]
        public int Id { get; set; }
        public DateTime When { get; set; }

        public List<SchedulesTasks> Tasks { get; set; }
    }
}

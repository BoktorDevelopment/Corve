using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CorveTool.DAL.Models
{
    public class Tasks : IDb
    {
        [Key]
        public int Id { get; set; }
        public string Task { get; set; }

        public List<SchedulesTasks> Schedules { get; set; }
    }
}

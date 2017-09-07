using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Models
{
    public class Schedules : IDb
    {
        [Key]
        public int Id { get; set;}
        public DateTime When { get; set; }
        
        public List<ScheduleTask> ScheduleTask { get; set; }
    }
}

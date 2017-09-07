using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CorveTool.DAL.Models
{
    public class ScheduleTask : IDb
    {
        
        [Key]
        public int Id { get; set; }


        public List<Schedules> Schedules { get; set; }
        public List<Tasks> Tasks { get; set; }
    }
}

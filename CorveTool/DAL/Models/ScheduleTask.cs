using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CorveTool.DAL.Models
{
    public class ScheduleTask : ISchedule
    {
        [Key]
        public int ID { get; set; }
        public int TaskID { get; set; }
        public int ScheduleID { get; set; }
    }
}

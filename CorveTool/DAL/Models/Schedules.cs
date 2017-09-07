using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Models
{
    public class Schedules 
    {
        [Key]
        public int ScheduleID { get; set;}
        public DateTime When { get; set; }
        public int TaskID { get; set; }
        public int UserID { get; set; }
    }
}

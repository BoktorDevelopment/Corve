using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Models
{
    public class ScheduleTask : IDb
    {
        [Key]
        public int Id { get; set; }  
        public string User { get; set; }
        public int Week { get; set; }
    }
}

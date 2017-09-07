using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Models
{
    interface ISchedule
    {
        int ID { get; set; }
        int TaskID { get; set; }
        int ScheduleID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CorveTool.DAL.Models
{
    public class Schedules : IDb
    {
        [Key]
        public int Id { get; set; }
        public DateTime When { get; set; }
    }
}

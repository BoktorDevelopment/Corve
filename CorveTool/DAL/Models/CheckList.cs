using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CorveTool.DAL.Models
{
    public class CheckList : IDb
    {
        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public bool Checked { get; set; }
        public int WeekNumber { get; set; }
    }
}

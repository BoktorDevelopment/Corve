using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Models;

namespace CorveTool.Models
{
    public class CheckListViewModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
        public bool Checked { get; set; }
        public int WeekNumber { get; set; }

     
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CorveTool.DAL.Models
{
    public class Tasks : ITasks
    {
        [Key]
        public int TaskID { get; set; }
        public string Task { get; set; }


    }
}
 
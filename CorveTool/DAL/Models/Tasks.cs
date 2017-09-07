using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CorveTool.DAL.Models
{
    public class Tasks : IDb
    {
        [Key]
        public int Id { get; set; }
        public string Task { get; set; }

        

    }
}
 
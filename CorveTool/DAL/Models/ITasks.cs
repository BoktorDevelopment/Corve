using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Models
{
    interface ITasks
    {
        int TaskID { get; set; }
        string Task { get; set; }
    }
}

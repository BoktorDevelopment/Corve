using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CorveTool.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<ScheduleTask> Schedule_Task { get; set; }
    }
}

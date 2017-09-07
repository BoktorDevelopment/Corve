using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Models;
using System.Data.Entity;

namespace CorveTool.DAL.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Tasks> Task { get; set; }
        public DbSet<Schedules> Schedule { get; set; }
        public DbSet<ScheduleTask> ScheduleTask { get; set; }
    }
}

using CorveTool.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CorveTool.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<ScheduleTask> Schedule_Task { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }
    }
}

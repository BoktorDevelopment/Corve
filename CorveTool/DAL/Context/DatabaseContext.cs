using CorveTool.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CorveTool.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        DbContextOptions<DatabaseContext> optie;

        public static string ConnectionString { get; set; }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<ScheduleTask> ScheduleTask { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<CheckList> CheckList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}

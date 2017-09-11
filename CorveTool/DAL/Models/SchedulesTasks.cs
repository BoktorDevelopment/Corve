namespace CorveTool.DAL.Models
{
    public class SchedulesTasks : IDb
    {
        public int Id { get; set; }
        public Schedules schedule { get; set; }
        public Tasks Task { get; set; }
    }
}

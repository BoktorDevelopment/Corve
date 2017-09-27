using CorveTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CorveTool.DAL.Repositories
{
    public class TaskRepository : Repository<Tasks>
    {
        public TaskRepository(DatabaseContext context) : base(context)
        {
            
        }
    }

    public class ScheduleTaskRepository : Repository<ScheduleTask>
    {
        public ScheduleTaskRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<ScheduleTask> FindByWeekAsync(int week)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Week == week);
        }

        public ScheduleTask FindByWeek(int week)
        {
            return GetAll().FirstOrDefault(x => x.Week == week);
        }
    }

    public class UsersRepository : Repository<Users>
    {
        public UsersRepository(DatabaseContext context) : base(context)
        {

        }
    }
    public class CheckListRepository : Repository<CheckList>
    {
        public CheckListRepository(DatabaseContext context) : base(context)
        {

        }
    }
    public class SchedulesRepository : Repository<Schedules>
    {
        public SchedulesRepository(DatabaseContext context) : base(context)
        {

        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Repositories;
using CorveTool.DAL.Models;
using CorveTool.DAL.Context;
using System.Globalization;

namespace CorveTool.Slack
{
    public class SlackClientTest
    {
        int week;


        public SlackClientTest()
        {
            
        }

        public void Postmessage()
        {
            var culture = CultureInfo.GetCultureInfo("cs-CZ");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            var dateTime = DateTime.Today;
            int weekNumber = culture.Calendar.GetWeekOfYear(dateTime, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);
            week = weekNumber;

            DatabaseContext context = new DatabaseContext();
            ScheduleTaskRepository scheduletaksrespository = new ScheduleTaskRepository(context);

            var result = context.ScheduleTask.Where(x => x.Week == week);


            string weburl = "https://hooks.slack.com/services/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";

            SlackClient client = new SlackClient(weburl);
            foreach (var item in result)
            {
                client.postMessage(username: "CorveeBot", text: item.User + " heeft deze week Corvée", channel: "#stage");
            }
        }
    }
}

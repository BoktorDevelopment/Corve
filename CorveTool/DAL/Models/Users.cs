using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CorveTool.DAL.Models
{
    public class Users : IUserData
    {
        public int UserId { get ; set; }
        public string FirstName { get; set ; }
        public string Insertion { get ; set ; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SlackName { get; set; }

       
       /* string IUserData.getSlackName()
        {
            return this.SlackName;
            fddsfsad
        }
        */
    }
}

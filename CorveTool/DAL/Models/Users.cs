using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CorveTool.DAL.Models { 
   
    public class Users : IUserData
    {
        [Key]
        public int UserId { get ; set; }
        public string FirstName { get; set ; }
        public string Insertion { get ; set ; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SlackName { get; set; }

        string IUserData.getFullName()
        {
            return this.FirstName + this.Insertion + this.LastName;
        }
    }
}

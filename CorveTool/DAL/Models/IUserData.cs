using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL
{
    public interface IUserData
    {
        [Key]
        int UserId { get; set; }
        string FirstName { get; set; }
        string Insertion { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string SlackName { get; set; }

        string getFullName();
    }
}

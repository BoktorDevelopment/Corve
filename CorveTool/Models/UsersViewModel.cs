using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CorveTool.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }

        
        [MinLength(2)]
        [MaxLength(60)]
        [Required]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(60)]
        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        [MinLength(2)]
        [MaxLength(60)]
        [Required]
        public string SlackName { get; set; }
    }
}

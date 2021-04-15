using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifty.Models
{
    public class EmployeeListItem
    {
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }        
        
        [Display(Name = "Days Working")]
        public List<string> ScheduledId { get; set; }

        [Display(Name = "Employee Requests")]
        public List<int> RequestId { get; set; }
     
    }
}


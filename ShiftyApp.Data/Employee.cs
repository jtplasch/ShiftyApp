using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftyApp.Data
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }        
        
        public virtual List<WorkSchedule> Dates { get; set; }
        public virtual List<Requests> RequestIds { get; set; }
    }
}

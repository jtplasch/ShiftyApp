using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftyApp.Data
{
    public class WorkSchedule
    {
        [Key]
        public int ScheduledId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int EmployeeId { get; set; }

        //virtual list showing list of employees for specific date
        //public virtual List<Employee> Employees{ get; set;}
    }
}

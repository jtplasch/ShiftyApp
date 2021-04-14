using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        //virtual list showing list of employees for specific date
        //public virtual List<Employee> Employees{ get; set;}
    }
}

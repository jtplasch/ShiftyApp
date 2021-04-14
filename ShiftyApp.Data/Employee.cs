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
        public int RequestId { get; set; }
        public int DateWorkingId { get; set; }

        //add virtual list of requests
        // add virtual list of dates working
        //public virtual List<DateWorking> DatesWorking { get; set; }
        //public virtual List<Request> Requests { get; set; }
    }
}

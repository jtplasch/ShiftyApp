using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifty.Models
{
    public class WorkScheduleCreate
    {
        [Required]
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
    }      
}

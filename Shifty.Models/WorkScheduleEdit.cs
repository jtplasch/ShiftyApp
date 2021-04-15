using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifty.Models
{
    public class WorkScheduleEdit
    {
        public int ScheduledId { get; set; }
        public string Date { get; set; }
        public int EmployeeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftyApp.Data
{
    public enum RequestType
    {
        Vacation,
        SickDays,
        Bereavement,
        Sabbatical,
        Maternity,
        Paternity,
        MedicalLeave,
        JuryDuty
    }
    public class Requests
    {
        [Key]
        public int RequestId { get; set; }
        [Required]
        public RequestType TypeOfRequest { get; set; }
        public string Reason { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}

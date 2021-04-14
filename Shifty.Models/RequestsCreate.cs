using ShiftyApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifty.Models
{
    public class RequestsCreate
    {
        [Required]
        public RequestType TypeOfRequest { get; set; }
        public string Reason { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
    }
}

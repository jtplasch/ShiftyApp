using ShiftyApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifty.Models
{
    public class RequestsDetail
    {
        [Key]
        public int RequestId { get; set; }
        [Required]
        public RequestType TypeOfRequest { get; set; }
        public string Reason { get; set; }
        [Required]
        public string Date { get; set; }

        [Required]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

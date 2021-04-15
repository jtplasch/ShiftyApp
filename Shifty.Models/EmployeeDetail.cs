using ShiftyApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifty.Models
{
    public class EmployeeDetail
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }

        public List<string> Dates { get; set; } = new List<string>();
        public List<int> RequestId { get; set; } = new List<int>();
    }
}

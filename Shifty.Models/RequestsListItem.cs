using ShiftyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifty.Models
{
    public class RequestsListItem
    {
        public int RequestId { get; set; }
        public RequestType TypeOfRequest { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public List<int> EmployeeId { get; set; }
    }
}

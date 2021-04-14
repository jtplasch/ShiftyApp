using Shifty.Models;
using ShiftyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifty.Services
{
    public class RequestsService
    {
        public bool CreateRequests(RequestsCreate model)
        {
            var entity =
                new Requests()
                {
                    TypeOfRequest = model.TypeOfRequest,
                    Reason = model.Reason,
                    Date = model.Date,
                    EmployeeId = model.EmployeeId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Requested.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RequestsListItem> GetRequests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Requested
                        //Dont need user Id because we don't have Guid
                        .Select(
                            e =>
                                new RequestsListItem
                                {
                                    RequestId = e.RequestId,
                                    TypeOfRequest = e.TypeOfRequest,
                                    Reason = e.Reason,
                                    Date = e.Date,                                    
                                }
                        );

                return query.ToArray();
            }
        }
    }
}

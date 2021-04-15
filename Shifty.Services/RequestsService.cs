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
        private readonly Guid _userId;

        public RequestsService(Guid userId)
        {
            _userId = userId;
        }
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
                var query = ctx.Requested.Select(e => new RequestsListItem
                {
                    RequestId = e.RequestId,
                    TypeOfRequest = e.TypeOfRequest,
                    Reason = e.Reason,
                    Date = e.Date
                });
                return query.ToArray();
            }
        }

        public RequestsDetail GetRequestsDetailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var requests = ctx.Requested.Single(s => s.RequestId == id);
                return new RequestsDetail
                {
                    RequestId = requests.RequestId,
                    TypeOfRequest = requests.TypeOfRequest,
                    Reason = requests.Reason,
                    Date = requests.Date,
                    EmployeeId = requests.EmployeeId
                };
            }
        }

        public bool UpdateRequests(RequestsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var requests = ctx.Requested.Single(s => s.RequestId == model.RequestId);
                requests.RequestId = model.RequestId;
                requests.TypeOfRequest = model.TypeOfRequest;
                requests.Reason = model.Reason;
                requests.Date = model.Date;
                requests.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteRequests(int requestId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Requested.Single(e => e.RequestId == requestId);
                ctx.Requested.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }


    }
}

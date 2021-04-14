using Shifty.Models;
using ShiftyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifty.Services
{
    public class WorkScheduleService
    {
        public bool CreateWorkSchedule(WorkScheduleCreate model)
        {
            var entity =
                new WorkSchedule()
                {                    
                    Date = model.Date,
                    EmployeeId = model.EmployeeId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.WorkSchedules.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkScheduleListItem> GetWorkSchedules()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WorkSchedules
                        //Dont need user Id because we don't have Guid
                        .Select(
                            e =>
                                new WorkScheduleListItem
                                {
                                    ScheduledId = e.ScheduledId,
                                    Date = e.Date
                                }
                        );

                return query.ToArray();
            }
        }
    }
}

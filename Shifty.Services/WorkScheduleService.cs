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
        private readonly Guid _userId;

        public WorkScheduleService(Guid userId)
        {
            _userId = userId;
        }
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

        public IEnumerable<WorkScheduleListItem> GetWorkSchedule()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.WorkSchedules.Select(e => new WorkScheduleListItem
                {
                    ScheduledId = e.ScheduledId,                    
                    Date = e.Date
                });
                return query.ToArray();
            }
        }

        public WorkScheduleDetail GetWorkScheduleDetailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var workSchedule = ctx.WorkSchedules.Single(s => s.ScheduledId == id);
                return new WorkScheduleDetail
                {
                    ScheduledId = workSchedule.ScheduledId,                    
                    Date = workSchedule.Date,
                    EmployeeId = workSchedule.EmployeeId
                };
            }
        }

        public bool UpdateWorkSchedule(WorkScheduleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var workSchedule = ctx.WorkSchedules.Single(s => s.ScheduledId == model.ScheduledId);
                workSchedule.ScheduledId = model.ScheduledId;                
                workSchedule.Date = model.Date;
                workSchedule.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteWorkSchedule(int scheduledId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.WorkSchedules.Single(e => e.ScheduledId == scheduledId);
                ctx.WorkSchedules.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

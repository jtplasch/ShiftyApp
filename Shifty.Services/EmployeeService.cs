using Shifty.Models;
using ShiftyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifty.Services
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }

        public EmployeeDetail GetEmployeeDetailById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var employee = ctx.Employees.Single(s => s.EmployeeId == id);
                return new EmployeeDetail
                {
                    EmployeeId = employee.EmployeeId,
                    FullName = employee.FullName,
                    Position = employee.Position,
                    Dates = employee.Dates.Select(x => x.Date).ToList(),
                    RequestId = employee.RequestIds.Select(x => x.RequestId).ToList()
                };
            }
        }
        public bool CreateEmployee(EmployeeCreate model)
        {
            

            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Employee()
                {
                    FullName = model.FullName,
                    Position = model.Position
                };

                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Employees.Select(e => new EmployeeListItem
                {
                    EmployeeId = e.EmployeeId,
                    FullName = e.FullName,
                    Position = e.Position
                });

                return query.ToArray();
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employee = ctx.Employees.Single(s => s.EmployeeId == model.EmployeeId);
                employee.FullName = model.FullName;
                employee.Position = model.Position;                

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteEmployee(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Employees.Single(e => e.EmployeeId == employeeId);
                ctx.Employees.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

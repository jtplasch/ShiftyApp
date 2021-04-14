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
        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    FullName = model.FullName,
                    Position = model.Position
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employees    
                        //Dont need user Id because we don't have Guid
                        .Select(
                            e =>
                                new EmployeeListItem
                                {
                                    EmployeeId = e.EmployeeId,
                                    FullName = e.FullName,
                                    Position = e.Position
                                }
                        );

                return query.ToArray();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.API.Models;
using TechZoneHRMS.Service.Interface;

namespace TechZoneHRMS.Service.Implement
{
    public class EmployeeService : ControllerBase, IEmployeeService
    {
        private readonly EmployeesManagementContext context;

        public EmployeeService(EmployeesManagementContext context)
        {
            this.context = context;
        }
        // GET: api/Employees

        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        public async Task<IActionResult> EditEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            context.Entry(employee).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.EmployeeStatus = !employee.EmployeeStatus;
            context.Entry(employee).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}

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
    public class DepartmentService : ControllerBase, IDepartmentService
    {
        private readonly EmployeesManagementContext context;

        public DepartmentService(EmployeesManagementContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await context.Departments.ToListAsync();
        }

        // GET: api/Departments/5
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var department = await context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        public async Task<IActionResult> EditDepartment(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            context.Entry(department).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            context.Departments.Add(department);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.DepartmentId }, department);
        }

        // DELETE: api/Departments/5
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            department.DepartmentStatus = !department.DepartmentStatus;
            context.Entry(department).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.API.Models;
using TechZoneHRMS.Domain.Models;
using TechZoneHRMS.Domain.Models.Department;
using TechZoneHRMS.Domain.Response;
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
        public async Task<IEnumerable<DepartmentDetail>> GetDepartments()
        {
            return (await context.Departments.ToListAsync()).Select(d => new DepartmentDetail()
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                DepartmentPhoneNumber = d.DepartmentPhoneNumber,
                DepartmentLocation = d.DepartmentLocation,
                DepartmentStatus = d.DepartmentStatus
            });
        }

        // GET: api/Departments/5
        public async Task<ActionResult<DepartmentDetail>> GetDepartmentById(int id)
        {
            var department = await context.Departments.FindAsync(id);
            
            if (department == null)
            {
                return NotFound();
            }
            DepartmentDetail departmentDetail = new DepartmentDetail()
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                DepartmentPhoneNumber = department.DepartmentPhoneNumber,
                DepartmentLocation = department.DepartmentLocation,
                DepartmentStatus = department.DepartmentStatus
            };
            return departmentDetail;
        }

        // PUT: api/Departments/5
        public async Task<ActionResult<Result>> EditDepartment(DepartmentDetail editdepartment)
        {
            var result = new Result()
            {
                Success = false,
                Message = "Something went wrong please try again!"
            };

            try
            {
                var department = await context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == editdepartment.DepartmentId);

                department.DepartmentId = editdepartment.DepartmentId;
                department.DepartmentName = editdepartment.DepartmentName;
                department.DepartmentLocation = editdepartment.DepartmentLocation;
                department.DepartmentPhoneNumber = editdepartment.DepartmentPhoneNumber;
                department.DepartmentStatus = editdepartment.DepartmentStatus;
                context.Entry(department).State = EntityState.Modified;
                if (await context.SaveChangesAsync() > 0)
                {
                    result.Success = true;
                    result.Message = "Product edited successfully";
                };
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        // POST: api/Departments
        public async Task<ActionResult<Result>> CreateDepartment(CreateDepartment create)
        {
            var result = new Result()
            {
                Success = false,
                Message = "Something went wrong please try again!"
            };
            try
            {
                var department = new Department()
                {
                    DepartmentName = create.DepartmentName,
                    DepartmentLocation = create.DepartmentLocation,
                    DepartmentPhoneNumber = create.DepartmentPhoneNumber,
                    DepartmentStatus = create.DepartmentStatus
                };

                context.Departments.Add(department);
                if (await context.SaveChangesAsync() > 0)
                {
                    result.Success = true;
                    result.Message = "Product created successfully";
                };
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }

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

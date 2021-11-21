using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.API.Models;
using TechZoneHRMS.Domain.Models.Employee;
using TechZoneHRMS.Domain.Response;
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

        public async Task<IEnumerable<EmployeeDetail>> GetEmployees()
        {
            return (await context.Employees.Include(em => em.Department).Include(em => em.EducationLevel).Include(em => em.Salary).ToListAsync()).Select(e => new EmployeeDetail()
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Gender = e.Gender,
                EmployeePhoneNumber = e.EmployeePhoneNumber,
                Email = e.Email,
                EmployeeAddress = e.EmployeeAddress,
                DateOfBirth = e.DateOfBirth,
                PlaceOfOrigin = e.PlaceOfOrigin,
                Ethnicity = e.Ethnicity,
                EmployeeAvatar = e.EmployeeAvatar,
                DepartmentName = e.Department.DepartmentName,
                BasicSalary = e.Salary.BasicSalary,
                Degree = e.EducationLevel.Degree,
                Major = e.EducationLevel.Major,
                EmployeeStatus = e.EmployeeStatus
            }
            );
        }

        // GET: api/Employees/5
        public async Task<ActionResult<EmployeeDetail>> GetEmployeeById(int id)
        {
            var employee = await context.Employees.Include(em => em.Department).Include(em => em.EducationLevel).Include(em => em.Salary).FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeDetail = new EmployeeDetail();
                employeeDetail.EmployeeId = employee.EmployeeId;
                employeeDetail.FirstName = employee.FirstName;
                employeeDetail.LastName = employee.LastName;
                employeeDetail.Gender = employee.Gender;
                employeeDetail.EmployeePhoneNumber = employee.EmployeePhoneNumber;
                employeeDetail.Email = employee.Email;
                employeeDetail.EmployeeAddress = employee.EmployeeAddress;
                employeeDetail.DateOfBirth = employee.DateOfBirth;
                employeeDetail.PlaceOfOrigin = employee.PlaceOfOrigin;
                employeeDetail.Ethnicity = employee.Ethnicity;
                employeeDetail.EmployeeAvatar = employee.EmployeeAvatar;
                employeeDetail.DepartmentName = employee.Department.DepartmentName;
                employeeDetail.BasicSalary = employee.Salary.BasicSalary;
                employeeDetail.Degree = employee.EducationLevel.Degree;
                employeeDetail.Major = employee.EducationLevel.Major;
                employeeDetail.EmployeeStatus = employee.EmployeeStatus;

            return employeeDetail;
        }

        // PUT: api/Employees/5
        public async Task<IActionResult> EditEmployee(int id, EditEmployee editEmployee)
        {
            var employee = await context.Employees.FindAsync(id);
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            employee.EmployeeId = id;
            employee.FirstName = editEmployee.FirstName;
            employee.LastName = editEmployee.LastName;
            employee.Gender = editEmployee.Gender;
            employee.EmployeePhoneNumber = editEmployee.EmployeePhoneNumber;
            employee.Email = editEmployee.Email;
            employee.EmployeeAddress = editEmployee.EmployeeAddress;
            employee.DateOfBirth = editEmployee.DateOfBirth;
            employee.PlaceOfOrigin = editEmployee.PlaceOfOrigin;
            employee.Ethnicity = editEmployee.Ethnicity;
            employee.EmployeeAvatar = editEmployee.EmployeeAvatar;
            employee.DepartmentId = editEmployee.DepartmentId;
            employee.SalaryId = editEmployee.SalaryId;
            employee.EducationLevelId = editEmployee.EducationLevelId;
            employee.EmployeeStatus = editEmployee.EmployeeStatus;

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
        public async Task<ActionResult<Result>> CreateEmployee(CreateEmployee createEmployee)
        {
            var result = new Result()
            {
                Success = false,
                Message = "Something went wrong please try again!"
            };
            try
            {
                var employee = new Employee()
                {
                    FirstName = createEmployee.FirstName,
                    LastName = createEmployee.LastName,
                    Gender = createEmployee.Gender,
                    EmployeePhoneNumber = createEmployee.EmployeePhoneNumber,
                    Email = createEmployee.Email,
                    EmployeeAddress = createEmployee.EmployeeAddress,
                    DateOfBirth = createEmployee.DateOfBirth,
                    PlaceOfOrigin = createEmployee.PlaceOfOrigin,
                    Ethnicity = createEmployee.Ethnicity,
                    EmployeeAvatar = createEmployee.EmployeeAvatar,
                    DepartmentId = createEmployee.DepartmentId,
                    SalaryId = createEmployee.SalaryId,
                    EducationLevelId = createEmployee.EducationLevelId,
                    EmployeeStatus = createEmployee.EmployeeStatus
                };

                context.Employees.Add(employee);
                if (await context.SaveChangesAsync() > 0)
                {
                    result.Success = true;
                    result.Message = "Employee created successfully";
                };
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
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

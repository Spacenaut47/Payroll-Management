using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayrollManagement.Core.DTOs.Employee;
using PayrollManagement.Core.Entities;
using PayrollManagement.Core.Interfaces;
using PayrollManagement.Core.Common;

namespace PayrollManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public EmployeesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeDto>>>> GetAll()
        {
            var employees = await _uow.Employees.GetAllAsync();
            var dtos = employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfJoining = e.DateOfJoining,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId
            });

            return Ok(new ApiResponse<IEnumerable<EmployeeDto>> { Data = dtos });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<EmployeeDto>>> Get(int id)
        {
            var e = await _uow.Employees.GetByIdAsync(id);
            if (e == null) return NotFound(new ApiResponse<EmployeeDto> { Success = false, Error = "Employee not found" });

            var dto = new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfJoining = e.DateOfJoining,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId
            };
            return Ok(new ApiResponse<EmployeeDto> { Data = dto });
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<EmployeeDto>>> Create([FromBody] EmployeeDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                DateOfJoining = dto.DateOfJoining,
                Salary = dto.Salary,
                DepartmentId = dto.DepartmentId
            };

            await _uow.Employees.AddAsync(employee);
            await _uow.CommitAsync();

            dto.Id = employee.Id;
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, new ApiResponse<EmployeeDto> { Data = dto });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<EmployeeDto>>> Update(int id, [FromBody] EmployeeDto dto)
        {
            var employee = await _uow.Employees.GetByIdAsync(id);
            if (employee == null) return NotFound(new ApiResponse<EmployeeDto> { Success = false, Error = "Employee not found" });

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.DateOfJoining = dto.DateOfJoining;
            employee.Salary = dto.Salary;
            employee.DepartmentId = dto.DepartmentId;

            _uow.Employees.Update(employee);
            await _uow.CommitAsync();

            return Ok(new ApiResponse<EmployeeDto> { Data = dto });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            var employee = await _uow.Employees.GetByIdAsync(id);
            if (employee == null) return NotFound(new ApiResponse<string> { Success = false, Error = "Employee not found" });

            _uow.Employees.Remove(employee);
            await _uow.CommitAsync();

            return Ok(new ApiResponse<string> { Data = "Deleted" });
        }
    }
}

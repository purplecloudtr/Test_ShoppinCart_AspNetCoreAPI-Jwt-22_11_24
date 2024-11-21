using AspNetCoreAPI_Jwt_Bearer.DTOs;
using AspNetCoreAPI_Jwt_Bearer.Entities;
using AspNetCoreAPI_Jwt_Bearer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAPI_Jwt_Bearer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var list = await _employeeService.GetAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.Get(id);
            if (employee == null)
            {
                return NotFound(id);
            }
            return Ok(employee);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] EmployeeDto employee)

        {
            var createdEmployee = await _employeeService.CreateAsync(employee);
            return CreatedAtAction(nameof(Get), new { id = createdEmployee.Id }, createdEmployee);
        }


        private IActionResult Created(string uri, object content, Employee createdEmployee)
        {
            return new CreatedResult(uri, content);
        }

    }
}

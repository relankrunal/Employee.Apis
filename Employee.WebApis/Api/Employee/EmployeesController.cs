using Employee.Services.Interfaces.Employees;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee.WebApis.Api.Employee
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("api/employees/{empId}")]
        public IActionResult GetEmployee(int empId)
        {
            // Your logic to retrieve employee details by ID
            // This could involve querying the database or any other data source

           // var employee = _employeeService.GetEmployeeById(empId);

            //if (employee == null)
            //{
            //    return NotFound(); // Return 404 Not Found if employee with given ID is not found
            //}

            return Ok(); // Return 200 OK with employee details if found
        }

    }
}
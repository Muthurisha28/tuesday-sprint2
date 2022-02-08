using CBMS.BAL.Service;
using CBMS.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("AddEmployeeDetails")]
        public IActionResult AddEmployeeDetails([FromBody] Employee employeedetails)
        {
            _employeeService.AddEmployeeDetails(employeedetails);

            return Ok("Employee Details Added Successfully!!!");
        }

        [HttpGet("GetEmployeeDetails")]
        public IEnumerable<Employee> GetEmployeeDetails()
        {
            return _employeeService.GetEmployeeDetails();
        }

        [HttpDelete("DeleteEmployeeDetails")]
        public IActionResult DeleteEmployeeDetails(int empNo)
        {
            _employeeService.DeleteEmployeeDetails(empNo);
            return Ok("Employee Details Deleted Successfully!!!");
        }

        [HttpPut("UpdateEmployeeDetails")]
        public IActionResult UpdateEmployeeDetails([FromBody] Employee employeeDetails)
        {
            _employeeService.UpdateEmployeeDetails(employeeDetails);
            return Ok("Employee Details Updated Successfully!!!");
        }
    }
}
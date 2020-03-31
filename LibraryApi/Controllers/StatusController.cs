using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class StatusController : Controller
    {
        [HttpGet("status")] // GET /status
        public ActionResult<StatusResponse> GetTheStatus()
        {
            var response = new StatusResponse
            {
                Status = "Looks good up here, captain!",
                CreatedAt = DateTime.Now
            };
            return Ok(response);
        }

        // Resource Archetypes
        // 1. Collection (usually plural, a set of things) /Employees
        // 2. Document (Singular. A single thingy)
        // 3. Store
        // 4. Controller

        // Getting information INTO the API
        // 1. Url
        //    a. Just plain ole' routing.
        //    b. Embed some variables in the route itself. e.g. GET /employees/657/salary

        [HttpGet("employees/{employeeId:int:min(1)}/salary")]
        public ActionResult GetEmployeeSalary(int employeeId)
        {
            //if(employeeId < 1)
            //{
            //    return NotFound();
            //}
            return Ok($"Employee {employeeId} has a salary of $65,000.00");
        }

        //    c. Add some data to the query string at the end of the URL e.g. GET /shoes?color=blue
        [HttpGet("shoes")]
        public ActionResult GetSomeShoes([FromQuery] string color = "All")
        {
            return Ok($"Getting you shoes of color {color}");
        }

        [HttpGet("whoami")]
        public ActionResult WhoAmI([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Ok($"You are using {userAgent}");
        }

        [HttpGet("employees")]
        public ActionResult GetAllEmployees()
        {
            return Ok("All the employees...");
        }

        [HttpPost("employees")]
        public ActionResult AddAnEmployee([FromBody] NewEmployee employee, [FromServices] IGenerateEmployeeIds idGenerator)
        {
            //var idGenerator = new EmployeeIdGenerator();
            var id = idGenerator.GetNewEmployeeId();
            return Ok($"Hiring {employee.Name} starting at {employee.StartingSalary.ToString("c")} with id of {id.ToString()}");
        }
    }


    public class NewEmployee
    {
        public string Name { get; set; }
        public decimal StartingSalary { get; set; }
    }



    public class StatusResponse
    {
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.test.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net.Mime;

namespace Test.test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostEnviroment;
        private readonly IConfiguration configuration;
        private readonly adventureContext dbcontext;

        public HomeController(adventureContext _context,IWebHostEnvironment hostingEnvironment, IConfiguration _configuration)
        {
            this._hostEnviroment = hostingEnvironment;
            this.dbcontext = _context;
            this.configuration = _configuration;
        }
        [HttpPost("Login")]
        public ActionResult Login()
        {
            return Json(new { message = "Logged In", Success = true });
        }
        [HttpPost("GetEmployeeData")]
        public ActionResult GetEmployeeData(int jobid)
        {
            var query = dbcontext.Employee.Where(x => x.job_id == jobid).ToList();
            return Json(new {data = query,count = query.Count});
        }
        [HttpPost("InsertUpdateEmployeeInfo")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult InsertUpdateEmployeeInfo(Employee employee)
        {
            var query = dbcontext.Employee.Where(x => x.employee_id == employee.employee_id).FirstOrDefault();
            if (query != null)
            {
                Employee insert = new Employee();
                insert.employee_id = employee.employee_id;
                insert.firstName = employee.firstName;
                insert.lastName = employee.lastName;
                insert.phone = employee.phone;
                insert.email = employee.email;
                insert.managerid = employee.managerid;
                insert.job_id = employee.job_id;
                insert.departmentid = employee.departmentid;
                insert.hireDate = employee.hireDate;
                insert.salary = employee.salary;
                dbcontext.Add(insert);
            }
            else
            {
                query.firstName = employee.firstName;
                query.lastName = employee.lastName;
                query.phone = employee.phone;
                query.email = employee.email;
                query.managerid = employee.managerid;
                query.job_id = employee.job_id;
                query.departmentid = employee.departmentid;
                query.hireDate = employee.hireDate;
                query.salary = employee.salary;
            }
            dbcontext.SaveChanges();
            return Ok();
        }
    }
}

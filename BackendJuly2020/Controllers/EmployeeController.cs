using BackendJuly2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendJuly2020.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            List<Employee> lstEmployee = new List<Employee>
            {
                new Employee {EmployeeId=1,EmployeeName="Erick",
                Designation="Mobile Dev",Department="IT",Qualification="Xamarin Forms"},
                new Employee {EmployeeId=2,EmployeeName="Roger",
                Designation="Web Dev",Department="IT",Qualification="Asp Core"}
            };
            return lstEmployee;
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}

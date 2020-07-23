﻿using BackendJuly2020.DAL;
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
        private EmployeeDAL _empDAL;
        public EmployeeController()
        {
            _empDAL = new EmployeeDAL();
        }

        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            return _empDAL.GetAll();
        }

        // GET: api/Employee/5
        public Employee Get(int id)
        {
            return _empDAL.GetById(id);
        }

        public IEnumerable<Employee> Get(string name)
        {
            return _empDAL.GetByName(name);
        }

        // POST: api/Employee
        public IHttpActionResult Post(Employee emp)
        {
            try
            {
                _empDAL.Insert(emp);
                return Ok($"Data Employee {emp.EmployeeName} berhasil ditambah");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendJuly2020.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        public string Department { get; set; }
    }
}
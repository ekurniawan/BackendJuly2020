using BackendJuly2020.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BackendJuly2020.DAL
{
    public class EmployeeDAL
    {
        private string GetConn()
        {
            return WebConfigurationManager
                .ConnectionStrings["MyConnection"].ConnectionString;
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> lstEmployee = new List<Employee>();
            using(SqlConnection conn = new SqlConnection(GetConn()))
            {
                string strSql = @"select * from Employees order by EmployeeName asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            lstEmployee.Add(new Employee { 
                                EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                                EmployeeName = dr["EmployeeName"].ToString(),
                                Designation = dr["Designation"].ToString(),
                                Department = dr["Department"].ToString(),
                                Qualification = dr["Qualification"].ToString()
                            });
                        }
                    }
                    dr.Close();
                    return lstEmployee;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
    }
}
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

        public Employee GetById(int id)
        {
            Employee objEmp = new Employee();
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                string strSql = @"select * from Employees 
                                  where EmployeeId=@EmployeeId";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@EmployeeId", id);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        objEmp.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        objEmp.EmployeeName = dr["EmployeeName"].ToString();
                        objEmp.Designation = dr["Designation"].ToString();
                        objEmp.Qualification = dr["Qualification"].ToString();
                        objEmp.Department = dr["Department"].ToString();
                    }
                    dr.Close();
                    return objEmp;
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

        public IEnumerable<Employee> GetByName(string name)
        {
            List<Employee> lstEmp = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                string strSql = @"select * from Employees 
                                where EmployeeName like @EmployeeName
                                order by EmployeeName asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@EmployeeName", "%" + name + "%");
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            lstEmp.Add(new Employee
                            {
                                EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                                EmployeeName = dr["EmployeeName"].ToString(),
                                Designation = dr["Designation"].ToString(),
                                Department = dr["Department"].ToString(),
                                Qualification = dr["Qualification"].ToString()
                            });
                        }
                    }
                    dr.Close();
                    return lstEmp;
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

        public void Insert(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                string strSql = @"insert into Employees(EmployeeName,Designation,Qualification,Department) 
                                values(@EmployeeName,@Designation,@Qualification,@Department)";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.Parameters.AddWithValue("@Qualification", emp.Qualification);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
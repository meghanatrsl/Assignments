﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace adonetdetails.model
{
    public class Studentdataaccess
    {
        string connectionString = "Data Source=(local);Initial Catalog=StudentDetails;Integrated Security=true ";

        //To View all employees details    
        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> lststudent = new List<Student>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();

                    student.StudentID = Convert.ToInt32(rdr["StudentID"]);
                    student.Name = rdr["Name"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                    student.Department = rdr["Department"].ToString();
                    student.City = rdr["City"].ToString();

                    lststudent.Add(student);
                }
                con.Close();
            }
            return lststudent;
        }

        //To Add new employee record    
        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Department", student.Department);
                cmd.Parameters.AddWithValue("@City", student.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar employee  
        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentId", student.StudentID);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Department", student.Department);
                cmd.Parameters.AddWithValue("@City", student.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular employee  
        public Student GetEmployeeData(int? id)
        {
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM TableStudent WHERE StudentID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    student.StudentID = Convert.ToInt32(rdr["StudentID"]);
                    student.Name = rdr["Name"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                    student.Department = rdr["Department"].ToString();
                    student.City = rdr["City"].ToString();
                }
            }
            return student;
        }

        //To Delete the record on a particular employee  
        public void DeleteStudent(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}

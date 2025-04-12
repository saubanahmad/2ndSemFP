using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.BL;

namespace LMS.DL
{
    internal class StudentDL
    {
        public static List<Student> students = new List<Student>();

        public static void AddStudent(Student s)
        {
            string query = $"INSERT INTO students VALUES  ('{s.Student_id}', '{s.Student_name}', '{s.Age}', '{s.Email}', '{s.Phone}', '{s.CNIC}', '{s.Guardian_name}', '{s.Guardian_phone}', '{s.Generated_password}')";
            DatabaseHelper.Instance.Update(query);
        }


        //public static void UpdateStudent()
        // make customized updation i.e.student can update any particular attribute 
    }
}

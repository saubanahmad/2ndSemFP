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
        public static List<Student> GetAllStudents()
        {
            string query = "SELECT * FROM students";
            var reader = DatabaseHelper.Instance.getData(query);
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student s = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                students.Add(s);
            }
            return students;
        }

        public static Student GetStudentById(string id)
        {
            string query = $"SELECT * FROM students WHERE Student_id = '{id}'";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                return new Student(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
            }
            return null;
        }
        public static void UpdateStudent(Student student)
        {
            string query = $"UPDATE students SET Student_name = '{student.Student_name}', Age = '{student.Age}', Email = '{student.Email}', Phone = '{student.Phone}', CNIC = '{student.CNIC}', Guardian_name = '{student.Guardian_name}', guardian_contact = '{student.Guardian_phone}' WHERE Student_id = {student.Student_id}";
            DatabaseHelper.Instance.Update(query);
        }
        public static int DeleteStudentFromDB(string id)
        {
            string query = $"DELETE FROM students WHERE Student_id = '{id}'";
            return DatabaseHelper.Instance.Update(query);
        }
        
    }
}

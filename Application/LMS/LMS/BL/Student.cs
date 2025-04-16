using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.DL;
using Org.BouncyCastle.Asn1.X509;

namespace LMS.BL
{
    internal class Student
    {
        public int Student_id { get; set; }
        public string Student_name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CNIC { get; set; }
        public string Guardian_name { get; set; }
        public string Guardian_phone { get; set; }
        public string Generated_password { get; set; }

        public Student(int Student_id, string Student_name, int Age, string Email, string Phone, string CNIC, string Guardian_name, string Guardian_phone, string Generated_password)
        {
            this.Student_id = Student_id;
            this.Student_name = Student_name;
            this.Age = Age;
            this.Email = Email;
            this.Phone = Phone;
            this.CNIC = CNIC;
            this.Guardian_name = Guardian_name;
            this.Guardian_phone = Guardian_phone;
            this.Generated_password = Generated_password;
        }
        public Student(string Student_name, int Age, string Email, string Phone, string CNIC, string Guardian_name, string Guardian_phone, string Generated_password)
        {
            this.Student_name = Student_name;
            this.Age = Age;
            this.Email = Email;
            this.Phone = Phone;
            this.CNIC = CNIC;
            this.Guardian_name = Guardian_name;
            this.Guardian_phone = Guardian_phone;
            this.Generated_password = Generated_password;
        }

        public static string GeneratePin()
        {
            Random random = new Random();
            int pin = random.Next(1000, 10000);
            return pin.ToString();
        }

        public static bool DeleteStudent(string id)
        {
            Student student = StudentDL.GetStudentById(id);
            if (student == null)
                return false;

            int rowsAffected = StudentDL.DeleteStudentFromDB(id);
            return rowsAffected > 0;
        }




        public static List<Student> GetAllStudents()
        {
            return StudentDL.GetAllStudents();
        }
 
       
    }
}

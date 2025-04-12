using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.BL;
using LMS.DL;

namespace LMS.UI
{
    internal class StudentUI
    {
        public static void add()
        {
            while (true)
            {
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Student's age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter email address: ");
                string email = Console.ReadLine();
                bool emailvalidation = Utilities.emailValidation(email);
                if (!emailvalidation)
                {
                    Console.WriteLine("Email format incorrect!");
                    Console.ReadKey();
                    continue;
                }
                Console.Write("Enter phone number: ");
                string phone = Console.ReadLine();
                Console.Write("Enter CNIC/ B-Form no.: ");
                string cnic = Console.ReadLine();
                Console.Write("Enter Guardian Name: ");
                string g_name = Console.ReadLine();
                Console.Write("Enter Guardian Contact: ");
                string g_phone = Console.ReadLine();
                string generated_password = Student.GeneratePin();
                Student s = new Student(name, age, email, phone, cnic, g_name, g_phone, generated_password);
                StudentDL.AddStudent(s);
                break;
            }
            Console.WriteLine("Student Added Successfully");
        }
    }
}

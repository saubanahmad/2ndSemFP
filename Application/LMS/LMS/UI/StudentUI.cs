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
        List<Student> students = Student.GetAllStudents();
        public static void add()
        {
            
            while (true)
            {
                Console.Clear();
                Utilities.header();
                Console.WriteLine("**********Add Student**********");
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
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static void ViewAllStudents()
        {
            Console.Clear();
            Utilities.header();
            Console.WriteLine("**********View All Students**********");
            List<Student> students = Student.GetAllStudents();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"{"ID",-10} {"Name",-20} {"Age",-5} {"Email",-30}");
            Console.WriteLine("----------------------------------------------------------------------");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Student_id,-10} {student.Student_name,-20} {student.Age,-5} {student.Email,-30}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static void UpdateStudent()
        {
            Console.Clear();
            Utilities.header();
            Console.WriteLine("**********Update Student**********");
            Console.Write("Enter Student ID to update: ");
            string id = Console.ReadLine();

            Student student = StudentDL.GetStudentById(id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            bool updating = true;
            while (updating)
            {
                Console.Clear();
                Utilities.header();
                Console.WriteLine("**********Update Student**********");
                Console.WriteLine("What do you want to update?");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Age");
                Console.WriteLine("3. Email");
                Console.WriteLine("4. Phone");
                Console.WriteLine("5. Guardian Name");
                Console.WriteLine("6. Guardian Contact");
                Console.WriteLine("7. Done");
                Console.Write("Enter option number: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter new Name: ");
                        student.Student_name = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Enter new Age: ");
                        if (int.TryParse(Console.ReadLine(), out int age))
                        {
                            student.Age = age;
                        }
                        else
                        {
                            Console.WriteLine("Invalid age input.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter new Email: ");
                        student.Email = Console.ReadLine();
                        break;
                    case "4":
                        Console.Write("Enter new Phone: ");
                        student.Phone = Console.ReadLine();
                        break;
                    case "5":
                        Console.Write("Enter new Guardian Name: ");
                        student.Guardian_name = Console.ReadLine();
                        break;
                    case "6":
                        Console.Write("Enter new Guardian Contact: ");
                        student.Guardian_phone = Console.ReadLine();
                        break;
                    case "7":
                        updating = false;
                        Console.WriteLine("Update Successful.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            StudentDL.UpdateStudent(student); // Save changes to DB/file
            Console.WriteLine("Student info updated successfully.");
        }
        public static void DeleteStudent()
        {
            Console.Clear();
            Utilities.header();
            Console.WriteLine("**********Delete Student**********");
            Console.Write("Enter Student ID to delete: ");
            string id = Console.ReadLine();

            bool success = Student.DeleteStudent(id);

            if (success)
                Console.WriteLine("Student deleted successfully.");
            else
                Console.WriteLine("Student not found.");
        }

    }
}

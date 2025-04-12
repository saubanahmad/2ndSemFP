using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.BL;
using LMS.DL;

namespace LMS.UI
{
    internal class UserUI
    {
        public static int Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string pass = Console.ReadLine();
            string password = User.HashPassword(pass);
            User u = new User(username, password);
            User.checkUser(u);
            string role = UserDL.GetRole(username);
            if (role == "admin")
            {
                Console.WriteLine("Successfully logged in as Administrator");
                return 1;
            }
            else if (role == "teacher")
            {
                Console.WriteLine("Successfully logged in as Teahcer");
                return 2;
            }
            else if (role == "student")
            {
                Console.WriteLine("Successfully logged in as Student");
                return 3;
            }
            else
            {
                return 4;
            }

        }
        public static void Add()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string pass = Console.ReadLine();
            string password = User.HashPassword(pass);
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter role(admin/teacher/student): ");
            string role = Console.ReadLine();
            int role_id = UserDL.GetRoleID(role);
            UserDL.AddUser(0, username, password, email, role_id);
            Console.Write("User added successfully");
            Console.ReadKey();
        }

    }
}

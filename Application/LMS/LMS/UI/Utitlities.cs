using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.UI
{
    internal class Utilities
    {
        public static void header()
        {
            System.Console.Clear();
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("*                                                                    *");
            Console.WriteLine("*    #####   ##### #   #  ###   ###  #       #     #     #  #####    *");
            Console.WriteLine("*   #       #      #   # #   # #   # #       #     # # # # #         *");
            Console.WriteLine("*    #####  #      ##### #   # #   # #       #     #  #  #  #####    *");
            Console.WriteLine("*         # #      #   # #   # #   # #       #     #     #       #   *");
            Console.WriteLine("*    #####   ##### #   #  ###   ###  #####   ##### #     #  #####    *");
            Console.WriteLine("*                                                                    *");
            Console.WriteLine("**********************************************************************");
        }
        public static int menu()
        {
            int option;
            Console.WriteLine("--Welcome to school learning management system--");
            Console.WriteLine("Select one of the following option numbers:- ");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your option: ");
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                Console.Write("Enter your option: ");
            }
            return option;
        }

        public static int adminMenu()
        {
            Console.WriteLine("Logged in as Administrator");
            Console.WriteLine("Select one of the following option numbers:- ");
            Console.WriteLine("1. Manage Students");
            Console.WriteLine("2. Manage Teachers");
            Console.WriteLine("3. Manage Courses");
            Console.WriteLine("Enter option Number: ");
            int option= int.Parse(Console.ReadLine());
            return option;
        }


        public static bool emailValidation(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            return email.Contains("@") && email.Contains(".");
        }

    }
}

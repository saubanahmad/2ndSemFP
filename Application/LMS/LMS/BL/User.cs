using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LMS.DL;

namespace LMS.BL
{
    internal class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int User_id { get; set; }
        public int Role_id { get; set; }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        //public Users(string Username, string Email, string Password, int Role_id)
        //{
        //    this.Username = Username;
        //    this.Email = Email;
        //    this.Password = Password;
        //    this.Role_id = Role_id;
        //}
        public User(int User_id, string Username, string Password, string Email, int Role_id)
        {
            this.Role_id = Role_id;
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            this.Role_id = Role_id;
        }
        public static List<User> users = new List<User>();
        public static User checkUser(User u)
        {
            UserDL.getUsers();
            foreach (var user in users)
            {
                if (user.Username == u.Username && VerifyPassword(u.Password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }

        private static readonly byte[] FixedSalt = Encoding.UTF8.GetBytes("ITECEventFixedSalt!");
        public static string HashPassword(string password)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, FixedSalt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[FixedSalt.Length + hash.Length];
            Array.Copy(FixedSalt, 0, hashBytes, 0, FixedSalt.Length);
            Array.Copy(hash, 0, hashBytes, FixedSalt.Length, hash.Length);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] storedHashValue = new byte[20];
            Array.Copy(hashBytes, FixedSalt.Length, storedHashValue, 0, 20);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, FixedSalt, 10000);
            byte[] enteredHash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (storedHashValue[i] != enteredHash[i])
                {
                    return false;
                }
            }
            return true;
        }


    }
}

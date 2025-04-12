using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.BL;

namespace LMS.DL
{
    internal class UserDL
    {
        public static List<User> users = new List<User>();

        public static void AddUser(int user_id, string username, string Password, string Email, int Role_id)
        {
            string query = $"INSERT INTO users VALUES  ('{user_id}', '{username}', '{Password}', '{Email}', '{Role_id}')";
            DatabaseHelper.Instance.Update(query);
        }
        public static void getUsers()
        {
            string query = "SELECT * FROM users";
            var reader = DatabaseHelper.Instance.getData(query);
            while (reader.Read())
            {
                int user_ID = Convert.ToInt32(reader["user_id"]);
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();
                string email = reader["email"].ToString();
                int role = Convert.ToInt32(reader["role_id"]);
                User u = new User(user_ID, username, password, email, role);
                users.Add(u);
            }
        }

        public static string GetRole(string username)
        {
            string query = $"SELECT distinct roles.role_name FROM roles JOIN users ON users.role_id = roles.role_id WHERE users.username = '{username}'";
            var reader = DatabaseHelper.Instance.getData(query);
            string role = "/0";
            while (reader.Read())
            {
                role = reader["role_name"].ToString();
            }
            return role;
        }

        public static int GetRoleID(string rolename)
        {
            string query = $"SELECT role_id FROM roles WHERE role_name = '{rolename}'";
            var reader = DatabaseHelper.Instance.getData(query);
            int roleid = 0;
            while (reader.Read())
            {
                roleid = Convert.ToInt32(reader["role_id"]);
            }
            return roleid;
        }
    }
}

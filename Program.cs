using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            while (true)
            {
                //Your code goes here
                Console.WriteLine("-------User Form-------");
                Console.WriteLine("1. User list");
                Console.WriteLine("2. Add user");
                Console.WriteLine("3. Edit user");
                Console.WriteLine("4. Delete user");
                Console.WriteLine("5. Exit");
                Console.WriteLine("-----------------------");
                String choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("User List");
                        userList();
                        Console.WriteLine("-------------------------------------");
                        break;
                    case "2":
                        Console.WriteLine("Add a new user.");
                        addUser();
                        Console.WriteLine("-------------------------------------");
                        break;
                    case "3":
                        editUser();
                        Console.WriteLine("User's information has been changed.");
                        break;
                    case "4":
                        deleteUser();
                        Console.WriteLine("User has been deleted.");
                        break;

                    case "5":
                        Console.WriteLine("Exit program.");
                        break;
                    default:
                        break;
                }
            }
        }

        public static void addUser()
        {
            User user = new User();
            Console.WriteLine("User's Id");
            user.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("User's name:");
            user.Name = Console.ReadLine();
            Console.WriteLine("User's phone:");
            user.Phone = Console.ReadLine();

            string sqlquery = "Insert into cdemo_user (Id, Name, Phone) values (" + user.Id + ",'" + user.Name + "','" + user.Phone + "'); ";
            MySqlCommand cmd = new MySqlCommand(sqlquery, ConnDB.ConnectionDB());
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            reader.Close();
        }

        public static void userList()
        {
            List<User> userList = new List<User>();

            string sqlquery = "select * from cdemo_user;";
            MySqlCommand cmd = new MySqlCommand(sqlquery, ConnDB.ConnectionDB());
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userList.Add(new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = Convert.ToString(reader["Name"]),
                    Phone = Convert.ToString(reader["Phone"])
                });
            }
        }

        public static User getUserById(int id)
        {
            string sqlquery = "select * from cdemo_user where id=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(sqlquery, ConnDB.ConnectionDB());
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            User e = null;
            if (reader.Read())
            {
                e = (new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = Convert.ToString(reader["Name"]),
                    Phone = Convert.ToString(reader["Phone"])
                });
            }
            else
            {
                Console.WriteLine("User hasnot been found.");
            }
            return e;
        }

        public static void editUser()
        {
            // 1. Bat nhap id.

            
            Console.WriteLine("User's Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            User exitUser = getUserById(id);
            if (exitUser != null)
            {

                Console.WriteLine("User's name:");
                string name = Console.ReadLine();
                Console.WriteLine("User's phone:");
                string phone = Console.ReadLine();

                string sqlquery = "Update cdemo_user set Name = '" + name + "', Phone = '" + phone + "' where Id =" + id + ";";
                Console.WriteLine(sqlquery);
                Console.ReadKey();
                MySqlCommand cmd = new MySqlCommand(sqlquery, ConnDB.ConnectionDB());
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void deleteUser()
        {
            Console.WriteLine("User's Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            User existUser = getUserById(id);
            if (existUser != null)
            {
                string sqlquery1 = "Delete from cdemo_user where Id=" + id + ";";
                MySqlCommand cmd = new MySqlCommand(sqlquery1, ConnDB.ConnectionDB());
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Not found.");
            }

        }
    }
}

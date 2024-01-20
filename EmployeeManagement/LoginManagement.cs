using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class LoginManagement
    {
        string m_username;
        string m_password;

        public string UserName
        {
            get => m_username; 
            set => m_username = value;
        }

        public string Password
        {
            get => m_password;
            set => m_password = value;
        }

        public bool checkRegex(string data, string validData)
        {
            Regex validRegexData = new Regex(validData);
            return validRegexData.IsMatch(data);
        }

        public void loginToSystem(JsonElement root)
        {
            Console.Clear();
            Console.WriteLine("******* LOGIN MENU *******");
            Console.WriteLine("Enter Username: ");
            m_username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            m_password = Console.ReadLine();
            string username = root.GetProperty("username").ToString();
            string password = root.GetProperty("password").ToString();
            //if (m_username != username || m_password != password)
            //{
            //    Console.WriteLine("Incorrect username or password!");
            //}

        }

        public void changePassword()
        {
            Console.Clear();
            string oldPassword;
            Console.WriteLine("******* CHANGE PASSWORD MENU *******");
            Console.WriteLine("Enter old password: ");
            oldPassword = Console.ReadLine();
            if (oldPassword == m_password)
            {
                Console.WriteLine("Enter new password: ");
                m_password = Console.ReadLine();
                Console.WriteLine("Change password successfully!");
            }
            else
            {
                Console.WriteLine("Enter wrong old password!");
            }
        }
    }
}

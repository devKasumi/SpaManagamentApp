using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class Employee
    {
        //private string m_ID;
        //private string m_Name;
        //private string m_dateOfBirth;
        //private string m_address;
        //private string m_empTitle;
        //private double m_salaryPerHour;
        string m_ID;    // default la private
        string m_Name;
        string m_dateOfBirth;
        string m_address;
        string m_empTitle;
        double m_salaryPerHour;
        public List<Date> listPaidDate = new List<Date>();

        //public Employee(string id, string name, string dateOfBirth, string address, string empTitle, double salaryPerHour)
        //{
        //    m_ID = id;
        //    m_Name = name;
        //    m_address = address;
        //    m_empTitle = empTitle;
        //    m_dateOfBirth = dateOfBirth;
        //    m_empTitle = empTitle;
        //    m_salaryPerHour = salaryPerHour;
        //}
        

        public string ID
        {
            get => m_ID;
            set => m_ID = value;
        }

        public string Name
        {
            get => m_Name;
            set => m_Name = value;
        }

        public string DateOfBirth
        {
            get => m_dateOfBirth;
            set => m_dateOfBirth = value;
        }

        public string Address
        {
            get => m_address;
            set => m_address = value;
        }

        public string EmpTitle
        {
            get => m_empTitle;
            set => m_empTitle = value;
        }

        public double SalaryPerHour
        {
            get => m_salaryPerHour;
            set => m_salaryPerHour = value;
        }

        public virtual void playrollInput()
        {

        }

        public virtual double salaryCalculating()
        {
            return 0;
        }

        public virtual double getIncomeMoney()
        {
            return 0;
        }

        public void enterEmpInfo(List<Employee> listEmployee)
        {
            string validInput = @"[0-1]{1}";
            bool check = true;
            bool checkInput = true;
            string inputChoice;
            string ID;
            do
            {
                int count = 0;
                Console.WriteLine("Enter Employee ID:");
                ID = Console.ReadLine();
                if (listEmployee.Count() != 0)
                {
                    for (int i = 0; i < listEmployee.Count(); i++)
                    {
                        if (listEmployee[i].ID == ID)
                        {
                            do
                            {
                                Console.WriteLine("Duplicate ID, choose 0 to exit, 1 to continue: ");
                                inputChoice = Console.ReadLine();
                                if (checkRegex(inputChoice, validInput))
                                {
                                    if (inputChoice == "0")
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection, please choose 0 or 1.");
                                    checkInput = false;
                                }
                                
                            } while (!checkInput);
                            break;
                        }
                        count++;
                    }
                    if (count == listEmployee.Count())
                    {
                        this.m_ID = ID;
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }
                }
                else
                {
                    this.m_ID = ID;
                    check = true;
                }
            } while (!check);
            validateNameInput();
            validateDateOfBirth();
            Console.WriteLine("Enter Employee Address: ");
            this.m_address = Console.ReadLine();
        }

        public bool checkRegex(string data, string validData)
        {
            Regex validRegexData = new Regex(validData);
            return validRegexData.IsMatch(data);
        }

        public void validateNameInput()
        {
            string validName = @"^[a-zA-Z_ ]*$";
            bool check = true;
            do
            {
                Console.WriteLine("Enter Employee name: ");
                this.m_Name = Console.ReadLine();
                if (checkRegex(this.m_Name, validName))
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Invalid name, please try again!");
                    check = false;
                }
            } while (!check);
        }

        public void validateDateOfBirth()
        {
            string validDateOfBirth = @"(19[0-9][0-9]|20[0-9][0-9])-(0[1-9]|[12]{1,2})-(0[1-9]|[12][0-9]|3[01]{1,2})";
            bool check = true; 
            do
            {
                Console.WriteLine("Enter Employee BirthDay (Format yyyy-mm-dd)");
                this.m_dateOfBirth = Console.ReadLine();
                if (checkRegex(this.m_dateOfBirth, validDateOfBirth))
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Invalid Date of Birth, please try again!");
                    check = false;
                }
            } while (!check);
        }

        public void validateSalaryInput()
        {
            bool check = true; 
            do
            {
                double validDoubleType;
                Console.WriteLine("Enter salary per hour: ");
                this.m_salaryPerHour = double.Parse(Console.ReadLine());
                bool isDouble = Double.TryParse(this.m_salaryPerHour.ToString(), out validDoubleType);
                if (isDouble){
                    if (this.m_salaryPerHour < 0.0)
                    {
                        Console.WriteLine("Invalid salary input, please try again!");
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid salary input, please try again!");
                    check = false;  
                }
            } while (!check);
        }

        
    }
}

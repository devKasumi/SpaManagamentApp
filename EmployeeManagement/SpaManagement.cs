using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EmployeeManagement
{
    internal class SpaManagement
    {
        int m_totalIncome;
        int m_profit;
        public List<Employee> listEmployee = new List<Employee>();


        public bool checkRegex(string data, string validInput)
        {
            Regex validData = new Regex(validInput);
            return validData.IsMatch(data);
        }

        public void printEmployeeInfo()
        {
            Console.Clear();
            Console.WriteLine("ID".PadLeft(10),         "|".PadLeft(1),
                              "Full name".PadLeft(20),  "|".PadLeft(1),
                              "Address".PadLeft(15),    "|".PadLeft(1),
                              "Birthday".PadLeft(15),   "|".PadLeft(1),
                              "Type");
            if (listEmployee.Count != 0)
            {
                for (int i = 0; i < listEmployee.Count; i++)
                {
                    Console.WriteLine(listEmployee[i].ID.PadLeft(10), "|".PadLeft(1),
                                      listEmployee[i].Name.PadLeft(20), "|".PadLeft(1),
                                      listEmployee[i].Address.PadLeft(15), "|".PadLeft(1),
                                      listEmployee[i].DateOfBirth.PadLeft(15), "|".PadLeft(1),
                                      listEmployee[i].EmpTitle);
                }
            }
            else
            {
                Console.WriteLine("No imformation!!");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();  
        }

        public void addEmployee()
        {
            Console.Clear();
            string validInput = @"[0-1]{1}";
            bool check = true;
            string dataInput = "";
            Console.WriteLine("******* ADD NEW EMPLOYEE MENU *******");
            do
            {
                Console.WriteLine("Enter Employee Type(0: Nail Technician, 1: Manager): ");
                dataInput = Console.ReadLine();
                if (checkRegex(dataInput, validInput)) {
                    if (dataInput == "0")
                    {
                        Employee employee = new Nailtechnician();
                        employee.enterEmpInfo(listEmployee);
                        if (employee.ID != "")
                        {
                            employee.EmpTitle = "Nail Technician";
                            employee.SalaryPerHour = 0;
                            listEmployee.Add(employee);
                        }
                        else
                        {
                            return;
                        }
                        check = true;
                    }
                    else
                    {
                        Employee employee = new Manager();
                        employee.enterEmpInfo(listEmployee);
                        if (employee.ID != "")
                        {
                            employee.EmpTitle = "Manager";
                            employee.validateSalaryInput();
                            listEmployee.Add(employee);
                        }
                        else
                        {
                            return;
                        }
                        check = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ivalid Selection, please choose 0 or 1!!");
                    check = false;
                }
            } while (!check);   
        }

        public void removeEmployee()
        {
            Console.Clear();
            string ID = "";
            int count = 0;
            int fixedSize = listEmployee.Count;
            Console.WriteLine("******* REMOVE EMPLOYEE MENU *******");
            Console.WriteLine("Enter Employee ID: ");
            ID = Console.ReadLine();
            if (listEmployee.Count != 0)
            {
                for (int i = 0; i < listEmployee.Count; i++)
                {
                    if (listEmployee[i].ID == ID)
                    {
                        listEmployee.RemoveAt(i);
                        Console.WriteLine("Remove Successfully!!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    count++;
                }
                if (count == fixedSize && listEmployee.Count == fixedSize)
                {
                    Console.WriteLine("System does not include this id, remove failed!!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("System does not include this id, remove dailed!!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public void updateEmployee()
        {
            Console.Clear();
            string ID = "";
            int count = 0;
            Console.WriteLine("******* UPDATE EMPLOYEE MENU *******\n\n");
            Console.WriteLine("Enter Employee ID: ");
            ID = Console.ReadLine();   
            if (listEmployee.Count != 0)
            {
                for (int i =0; i < listEmployee.Count;i++)
                {
                    if (listEmployee[i].ID == ID)
                    {
                        string validInput = @"[0-3]{1}";
                        bool check = true;
                        string select = "";
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("******* UPDATE EMPLOYEE MENU *******\n");
                            Console.WriteLine("[1]: Update Name.");
                            Console.WriteLine("[2]: Update Address.");
                            Console.WriteLine("[3]: Update Date of Birth.");
                            Console.WriteLine("[0]L Exit.");

                            do
                            {
                                Console.WriteLine("Enter your choice (interger): ");
                                select = Console.ReadLine();
                                if (checkRegex(select, validInput))
                                {
                                    check = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please enter interger from 0 to 3 !!");
                                    check = false;
                                }
                            } while(!check);

                            switch (int.Parse(select))
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.Clear();
                                    string validName = @"^[a-zA-Z_ ]*$";
                                    string newName = "";
                                    Console.WriteLine("******* UPDATE EMPLOYEE MENU *******\n");
                                    do
                                    {
                                        Console.WriteLine("Enter new employee name: ");
                                        newName = Console.ReadLine();
                                        if (checkRegex(newName, validName))
                                        {
                                            listEmployee[i].Name = newName;
                                            check = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ivalid name, please try again!!!");
                                            check = false;
                                        }
                                    } while(!check);
                                    break;
                                case 2:
                                    Console.Clear();
                                    string newAddress = "";
                                    Console.WriteLine("******* UPDATE EMPLOYEE MENU *******\n\n");
                                    Console.WriteLine("Enter new employee address: ");
                                    newAddress = Console.ReadLine();
                                    listEmployee[i].Address = newAddress;
                                    break;
                                case 3:
                                    Console.Clear();
                                    string validDateOfBirth = @"(19[0-9][0-9]|20[0-9][0-9])-(0[1-9]|[12]{1,2})-(0[1-9]|[12][0-9]|3[01]{1,2})";
                                    string newBirthDay = "";
                                    Console.WriteLine("******* UPDATE EMPLOYEE MENU *******");
                                    do
                                    {
                                        Console.WriteLine("Enter new employee birthday (Format yyyy-MM-dd): ");
                                        newBirthDay = Console.ReadLine();
                                        if (checkRegex(newBirthDay, validDateOfBirth))
                                        {
                                            listEmployee[i].DateOfBirth = newBirthDay;
                                            check = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid birthday, please try again!!");
                                            check = false;
                                        }
                                    }while (!check);
                                    break;
                                default:
                                    break;
                            }
                        } while (!check);
                        break;
                    }
                    count++;
                }
                if (count == listEmployee.Count)
                {
                    Console.WriteLine("System dose not include this id, remove failed!!!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("System does not include this id, remove failed!!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public void searchEmployee()
        {
            Console.Clear();
            string ID = "";
            Console.WriteLine("******* SEARCH EMPLOYEE MENU *******\n");
            Console.WriteLine("Enter Employee ID: ");
            ID = Console.ReadLine();
            int count = 0;
            if (listEmployee.Count != 0)
            {
                for (int i = 0; i < listEmployee.Count; i++)
                {
                    if (listEmployee[i].ID == ID)
                    {
                        Console.Clear();
                        Console.WriteLine("ID".PadLeft(10),         "|".PadLeft(1),
                                          "Full Name".PadLeft(20),  "|".PadLeft(1),
                                          "Address".PadLeft(15),    "|".PadLeft(1),
                                          "Birthday".PadLeft(15),   "|".PadLeft(1),
                                          "Type".PadLeft(15),       "|".PadLeft(1),
                                          "Salary/hour(unit$)\n");
                        Console.WriteLine(listEmployee[i].ID.PadLeft(10),           "|".PadLeft(1),
                                          listEmployee[i].Name.PadLeft(20),         "|".PadLeft(1),
                                          listEmployee[i].Address.PadLeft(15),      "|".PadLeft(1),
                                          listEmployee[i].DateOfBirth.PadLeft(15),  "|".PadLeft(1),
                                          listEmployee[i].EmpTitle.PadLeft(15),     "|".PadLeft(1),
                                          listEmployee[i].SalaryPerHour);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    count++;
                }
                if (count == listEmployee.Count)
                {
                    Console.WriteLine("System does not include this id.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("System does not include this id.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public void incomeAndProfitCalculating()
        {
            Console.Clear();
            string validDate = @"(19[0-9][0-9]|20[0-9][0-9])-(0[1-9]|[12]{1,2})-(0[1-9]|[12][0-9]|3[01]{1,2})";
            string startDate = "";
            string endDate = "";
            double totalIncome = 0;
            double profit = 0;
            double totalPaidSalary = 0;
            bool check = true;
            string exit = "";
            List<Dictionary<string, double>> listEmpAndPaidDate = new List<Dictionary<string, double>>();   

            Console.WriteLine("******* CALCULATE SALARY AND PROFIT MENU *******");
            do
            {
                Console.WriteLine("Enter start date (Format yyyy-MM-dd): ");
                startDate = Console.ReadLine();
                if (checkRegex(startDate, validDate))
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Invalid date!");
                    check = false;
                }
            } while (!check);

            do
            {
                Console.WriteLine("Enter end date (Format yyyy-MM-dd): ");
                endDate = Console.ReadLine();
                if (checkRegex(endDate, validDate))
                {
                    if (String.Compare(endDate, startDate) < 0)
                    {
                        Console.WriteLine("You do not enter the date before start date!");
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Date");
                    check = false;
                }
            }while (!check);

            if (listEmployee.Count != 0)
            {
                for (int i = 0; i< listEmployee.Count; i++)
                {
                    if (listEmployee[i].listPaidDate.Count != 0)
                    {
                        for (int j = 0; j < listEmployee[i].listPaidDate.Count; j++)
                        {
                            if (String.Compare(listEmployee[i].listPaidDate[j].PaidDate, startDate) >= 0 && String.Compare(listEmployee[i].listPaidDate[j].PaidDate, endDate) <= 0)
                            {
                                Dictionary<string, double> pair = new Dictionary<string, double>();
                                pair.Add(listEmployee[i].ID, listEmployee[i].listPaidDate[j].PaidSalary);
                                listEmpAndPaidDate.Add(pair);
                                totalIncome += listEmployee[i].listPaidDate[j].IncomeMoney;
                                totalPaidSalary += listEmployee[i].listPaidDate[j].PaidSalary;
                            }
                        }
                    }
                }
            }

            profit = totalIncome - totalPaidSalary;
            Console.Clear();
            Console.WriteLine("Total Income (unit $): ", totalIncome);
            Console.WriteLine("Profit (unit $): ", profit);
            Console.WriteLine("Salary for each employee: ");
            Console.WriteLine("ID".PadLeft(15), "|".PadLeft(15), "Salary (unit $)");
            for (int i = 0;i<listEmpAndPaidDate.Count;i++)
            {
                Console.WriteLine(listEmpAndPaidDate[i].Keys.ToString().PadLeft(15), "|".PadLeft(15), listEmpAndPaidDate[i].Values.ToString());
            }

            do
            {
                Console.WriteLine("Enter 0 to exit: ");
                exit = Console.ReadLine();
                if (exit == "0")
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Enter 0 only, please try again!");
                    check = false;
                }
            } while (!check);

        }



    }
}

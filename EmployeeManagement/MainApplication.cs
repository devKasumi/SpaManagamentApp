using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class MainApplication
    {
        SpaManagement spaManage = new SpaManagement();
        LoginManagement userLogin = new LoginManagement();
        Encryption encryptDecrypt = new Encryption();

        public int select = 0;
        public int selectMainMenu = 0;
        public int selectEmpManagementMenu = 0;
        public int selectPayrollManageMenu = 0;

        string validInputForWelcomeMenu = @"[0-1]{1}";
        string validInputForMainMenu = @"[0-3]{1}";
        string validInputForEmpManagementMenu = @"[0-5]{1}";
        string validInputForPayrollManagementMenu = @"[0-2]{1}";

        public void RunApp()
        {
            downloadDataFromJsonFile();
            //int select = 0;
            do
            {
                Console.Clear();
                WelcomeMenu();
                checkDataInputForMenu(validInputForWelcomeMenu);
                switch (select)
                {
                    case 1:
                        {
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
                            string jsonData = File.ReadAllText(path);
                            JsonDocument doc = JsonDocument.Parse(jsonData);
                            JsonElement root = doc.RootElement;
                            userLogin.loginToSystem(root);
                            string username = encryptDecrypt.Decrypt(root.GetProperty("username").ToString());
                            string password = encryptDecrypt.Decrypt(root.GetProperty("password").ToString());
                            if (userLogin.UserName == username && userLogin.Password == password)
                            {
                                Console.WriteLine("Login Success.");
                                Console.WriteLine("Press any key to continue!!");
                                Console.ReadKey();
                                //int selectMainMenu = 0;
                                do
                                {
                                    Console.Clear();
                                    MainMenu();
                                    checkDataInputForMenu(validInputForMainMenu);
                                    switch (selectMainMenu)
                                    {
                                        case 1:
                                            {
                                                //int selectEmpManagementMenu = 0;
                                                do
                                                {
                                                    Console.Clear();
                                                    EmployeeManagementMenu();
                                                    checkDataInputForMenu(validInputForEmpManagementMenu);
                                                    switch (selectEmpManagementMenu)
                                                    {
                                                        case 1:
                                                            {
                                                                updateData();
                                                                spaManage.printEmployeeInfo();
                                                                Console.WriteLine("Success Displaying Information");
                                                                outputDataToJsonFile();
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                updateData();
                                                                spaManage.addEmployee();
                                                                Console.WriteLine("Success Adding Information");
                                                                outputDataToJsonFile();
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                updateData();
                                                                spaManage.removeEmployee();
                                                                Console.WriteLine("Success Removing Information");
                                                                outputDataToJsonFile();
                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                updateData();
                                                                spaManage.updateEmployee();
                                                                Console.WriteLine("Success Updating Information");
                                                                outputDataToJsonFile();
                                                                break;
                                                            }
                                                        case 5:
                                                            {
                                                                updateData();
                                                                spaManage.searchEmployee();
                                                                Console.WriteLine("Success Searching Information");
                                                                outputDataToJsonFile();
                                                                break;
                                                            }
                                                        case 0:
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                } while (selectEmpManagementMenu != 0);
                                                break;
                                            }
                                        case 2:
                                            {
                                                //int selectPayrollManageMenu = 0;
                                                do
                                                {
                                                    Console.Clear();
                                                    PayrollManagementMenu();
                                                    checkDataInputForMenu(validInputForPayrollManagementMenu);
                                                    switch (selectPayrollManageMenu)
                                                    {
                                                        case 1:
                                                            {
                                                                updateData();
                                                                Date date = new Date();
                                                                paidDate(spaManage.listEmployee, date);
                                                                Console.WriteLine("Success Getting PaidDate For Each Employee");
                                                                outputDataToJsonFile();
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                spaManage.incomeAndProfitCalculating();
                                                                Console.WriteLine("Success Calculating Income and Profit");
                                                                break;
                                                            }
                                                        case 0:
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                } while (selectPayrollManageMenu != 0);
                                                break;
                                            }
                                        case 3:
                                            {
                                                updateData();
                                                userLogin.changePassword();
                                                Console.WriteLine("Success Changing Password");
                                                outputDataToJsonFile();
                                                break;
                                            }
                                        case 0:
                                            break;
                                        default:
                                            break;
                                    }
                                } while (selectMainMenu != 0);
                            }
                        }
                        break;
                }
            } while (select != 0);
            
        }

        public void WelcomeMenu()
        {
            Console.WriteLine("WELCOME TO SPA MANAGEMENT SYSTEM MENU");
            Console.WriteLine("MENU:");
            Console.WriteLine("    [1]. Login.");
            Console.WriteLine("    [0]. Exit.");
        }

        public void MainMenu()
        {
            Console.WriteLine("******* MAIN MENU *******");
            Console.WriteLine("[1]: Employee Management");
            Console.WriteLine("[2]: Payroll Management");
            Console.WriteLine("[3]: Change Password.");
            Console.WriteLine("[0]: Exit.");
        }

        public void EmployeeManagementMenu()
        {
            Console.WriteLine("******* EMPLOYEE MANAGEMENT MENU *******");
            Console.WriteLine("[1]: Print all employee's information.");
            Console.WriteLine("[2]: Add new employee.");
            Console.WriteLine("[3]: Remove an employee by ID.");
            Console.WriteLine("[4]: Update employee's information by ID.");
            Console.WriteLine("[5]: Search employee's information by ID.");
            Console.WriteLine("[0]: Exit.");
        }

        public void PayrollManagementMenu()
        {
            Console.WriteLine("******* PAYROLL MANAGEMENT MENU *******");
            Console.WriteLine("[1]: Input payroll for employee.");
            Console.WriteLine("[2]: Calculate salary and profit.");
            Console.WriteLine("[0]: Exit.");
        }

        public bool checkRegex(string data, string validInput)
        {
            Regex validData = new Regex(validInput);
            return validData.IsMatch(data);
        }

        public void checkDataInputForMenu(string validInput)
        {
            bool check = true;
            do
            {
                Console.WriteLine("Enter your choice (interger): ");
                string data = Console.ReadLine();
                if (checkRegex(data, validInput))
                {
                    if (validInput.Equals(validInputForWelcomeMenu))
                    {
                        select = int.Parse(data);
                    }
                    else if (validInput.Equals(validInputForMainMenu))
                    {
                        selectMainMenu = int.Parse(data);
                    }
                    else if (validInput.Equals(validInputForEmpManagementMenu))
                    {
                        selectEmpManagementMenu = int.Parse(data);  
                    }
                    else selectPayrollManageMenu = int.Parse(data); 
                    check = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again!");
                    check = false;
                }

            } while (!check);
        }

        public string getCurrentDate()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate.ToString("yyyy-MM-dd");
        }

        public void paidDate(List<Employee> listEmployee, Date date)
        {
            Console.Clear();
            string ID = "";
            string paidDate = "";
            string validPaidDate = @"(19[0-9][0-9]|20[0-9][0-9])-(0[1-9]|[12]{1,2})-(0[1-9]|[12][0-9]|3[01]{1,2})";
            bool check = true;
            int count = 0;

            Console.WriteLine("******* PAYROLL INPUT MENU *******");
            do
            {
                Console.WriteLine("Enter Date (Format yyyy-mm-dd): ");
                paidDate = Console.ReadLine();
                if (checkRegex(paidDate, validPaidDate))
                {
                    if (String.Compare(paidDate, getCurrentDate()) > 0)
                    {
                        Console.WriteLine("Invalid date !");
                        Console.WriteLine("Press any key to continue!!");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        check = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Data, please try again!");
                    check = false;
                }
            } while (!check);

            Console.WriteLine("Enter Employee id: ");
            ID = Console.ReadLine();
            if (listEmployee.Count > 0)
            {
                for (int i = 0; i < listEmployee.Count; i++)
                {
                    if (listEmployee[i].ID == ID)
                    {
                        listEmployee[i].playrollInput();
                        date.PaidDate = paidDate;
                        date.PaidSalary = listEmployee[i].salaryCalculating();
                        date.IncomeMoney = listEmployee[i].getIncomeMoney();
                        listEmployee[i].listPaidDate.Add(date);
                        break;
                    }
                    count++;
                }
                if (count == listEmployee.Count)
                {
                    Console.WriteLine("Invalid employee!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid employee!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public void downloadDataFromJsonFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
            string jsonData = File.ReadAllText(path);
            JsonDocument doc = JsonDocument.Parse(jsonData);
            JsonElement root = doc.RootElement;
            string username = root.GetProperty("username").ToString();
            string password = root.GetProperty("password").ToString();
            userLogin.UserName = encryptDecrypt.Decrypt(username);
            userLogin.Password = encryptDecrypt.Decrypt(password);
            JsonElement employeeInfo = root.GetProperty("information");
            if (root.GetProperty("information").GetArrayLength() != 0)
            {
                for (int i = 0; i < employeeInfo.GetArrayLength(); i++)
                {
                    string checkTitle = employeeInfo[i].GetProperty("Title").ToString();
                    if (encryptDecrypt.Decrypt(checkTitle).ToString() == "manager")
                    {
                        Employee employee = new Manager();
                        parseEmployeeInfo(employee, employeeInfo[i]);
                        spaManage.listEmployee.Add(employee);
                    }
                    else
                    {
                        Employee employee = new Nailtechnician();
                        parseEmployeeInfo(employee, employeeInfo[i]);
                        spaManage.listEmployee.Add(employee);
                    }
                }
            }

        }


        public void parseEmployeeInfo(Employee employee, JsonElement employeeInfo)
        {
            string ID = employeeInfo.GetProperty("ID").ToString();
            string Name = employeeInfo.GetProperty("Name").ToString();
            string Address = employeeInfo.GetProperty("Address").ToString();
            string DateOfBirth = employeeInfo.GetProperty("Birthday").ToString();
            string EmpTitle = employeeInfo.GetProperty("Title").ToString();
            string Salary = "";
            if (employeeInfo.TryGetProperty("Salary", out employeeInfo))
            {
                Salary = employeeInfo.GetProperty("Salary").ToString();
                employee.SalaryPerHour = Convert.ToDouble(Salary);
            }
            //string Salary = employeeInfo.GetProperty("Salary").ToString();
            employee.ID = encryptDecrypt.Decrypt(ID);
            employee.Name = encryptDecrypt.Decrypt(Name);
            employee.Address = encryptDecrypt.Decrypt(Address);
            employee.DateOfBirth = encryptDecrypt.Decrypt(DateOfBirth);
            employee.EmpTitle = encryptDecrypt.Decrypt(EmpTitle);
            JsonElement paidDateArray;
            if (employeeInfo.TryGetProperty("PaidDate", out employeeInfo))
            {
                paidDateArray = employeeInfo.GetProperty("PaidDate");
                //if (paidDateArray.GetArrayLength() != 0)
                //{
                //    for (int j = 0; j < paidDateArray.GetArrayLength(); j++)
                //    {
                //        Date date = new Date();
                //        string PaidDate = paidDateArray[j].GetProperty("Date").ToString();
                //        string PaidSalary = paidDateArray[j].GetProperty("DailySalary").ToString();
                //        string IncomeMoney = paidDateArray[j].GetProperty("IncomeMoney").ToString();
                //        date.PaidDate = PaidDate;
                //        date.PaidSalary = Convert.ToDouble(PaidSalary);
                //        date.IncomeMoney = Convert.ToDouble(IncomeMoney);
                //        employee.listPaidDate.Add(date);
                //    }
                //}
            }

        }

        public void updateData()
        {
            spaManage = new SpaManagement();
            userLogin = new LoginManagement();
            encryptDecrypt = new Encryption();
            downloadDataFromJsonFile();
        }

        public void outputDataToJsonFile()
        {
            string username = userLogin.UserName;
            string password = userLogin.Password;
            //JsonElement json = new JsonElement();
            using var ms = new MemoryStream();
            using var writer = new Utf8JsonWriter(ms);
            writer.WriteStartObject();
            writer.WriteString("username", encryptDecrypt.Encrypt(username));
            writer.WriteString("password", encryptDecrypt.Encrypt(password));
            writer.WriteStartArray("information");
            if (spaManage.listEmployee.Count != 0)
            {
                for (int i = 0; i < spaManage.listEmployee.Count; i++)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("ID");
                    writer.WriteStringValue(encryptDecrypt.Encrypt(spaManage.listEmployee[i].ID));
                    writer.WritePropertyName("Name");
                    writer.WriteStringValue(encryptDecrypt.Encrypt(spaManage.listEmployee[i].Name));
                    writer.WritePropertyName("Address");
                    writer.WriteStringValue(encryptDecrypt.Encrypt(spaManage.listEmployee[i].Address));
                    writer.WritePropertyName("Birthday");
                    writer.WriteStringValue(encryptDecrypt.Encrypt(spaManage.listEmployee[i].DateOfBirth));
                    writer.WritePropertyName("Title");
                    writer.WriteStringValue(encryptDecrypt.Encrypt(spaManage.listEmployee[i].EmpTitle));
                    if (spaManage.listEmployee[i].listPaidDate.Count != 0)
                    {
                        writer.WriteStartArray("PaidDate");
                        for (int j = 0; j < spaManage.listEmployee[i].listPaidDate.Count; j++)
                        {
                            writer.WriteStartObject();
                            writer.WritePropertyName("Date");
                            writer.WriteStringValue(encryptDecrypt.Encrypt(spaManage.listEmployee[i].listPaidDate[j].PaidDate));
                            writer.WritePropertyName("DailySalary");
                            writer.WriteStringValue(encryptDecrypt.Encrypt(spaManage.listEmployee[i].listPaidDate[j].PaidSalary.ToString()));
                            writer.WritePropertyName("IncomeMoney");
                            writer.WriteStringValue(encryptDecrypt.Encrypt(spaManage.listEmployee[i].listPaidDate[j].IncomeMoney.ToString()));
                            writer.WriteEndObject();
                        }
                        writer.WriteEndArray();

                    }
                    writer.WriteEndObject();
                }
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Flush();

            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            var path = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
            File.WriteAllText(path, jsonString);
        }


    }
}

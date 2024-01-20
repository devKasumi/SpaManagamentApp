using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class Manager : Employee
    {
        private double m_hoursPerDay;
        public Manager()
        {
            m_hoursPerDay = 0;
        }

        public override void playrollInput() 
        {
            Console.Clear();
            bool check = true;
            Console.WriteLine("******* PAYROLL INPUT FOR MANAGER MENU *******");
            do
            {
                Console.WriteLine("Enter working hours per day (unit hour): ");
                double validDoubleType;
                this.m_hoursPerDay = double.Parse(Console.ReadLine());
                bool isDouble = Double.TryParse(this.m_hoursPerDay.ToString(), out validDoubleType);
                if (isDouble)
                {
                    if (this.m_hoursPerDay < 0.0)
                    {
                        Console.WriteLine("Invalid hour input, please try again!");
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid hour input, please try again!");
                    check = false;
                }
            } while (!check);
        }

        public override double salaryCalculating() => (double)(m_hoursPerDay * SalaryPerHour);

        public override double getIncomeMoney() => 0;

    }
}

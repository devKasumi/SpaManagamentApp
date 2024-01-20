using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class Nailtechnician : Employee
    {
        private double m_receiptMoney;
        private double m_tipsMoney;

        public Nailtechnician()
        {
            m_receiptMoney = 0;
            m_tipsMoney = 0;
        }

        public override void playrollInput()
        {
            //base.playrollInput();
            Console.Clear();
            bool check = true;
            int count = 0;
            string moneyInput = "";
            Console.WriteLine("******* PAYROLL INPUT FOR NAIL TECHNICIAN MENU *******");
            moneyInputFromUser(check, count, moneyInput, m_receiptMoney);
            count = 0;
            moneyInputFromUser(check, count, moneyInput, m_tipsMoney);
        }

        public void moneyInputFromUser(bool check, int count, string moneyInput, double typeOfMoney)
        {
            do
            {
                Console.WriteLine("Enter money(split + by each receipt, unit $), no space between words: ");
                moneyInput = Console.ReadLine();
                for (int i = 0; i < moneyInput.Length; i++)
                {
                    int digit = (int)moneyInput[i];
                    if ((digit < 48 && digit != 43) || digit > 57)
                    {
                        Console.WriteLine("Invalid money input, please try again!");
                        check = false;
                        break;
                    }
                    count++;
                }
                if (count == moneyInput.Length)
                {
                    List<string> listNumber = new List<string>();
                    string temp = "";
                    for (int i = 0; i < moneyInput.Length;i++)
                    {
                        if (moneyInput[i] != '+')
                        {
                            temp += moneyInput[i];
                        }
                        else
                        {
                            typeOfMoney += Convert.ToDouble(temp);
                            temp = "";
                        }
                    }
                    Stack<char> numStack = new Stack<char>();
                    int count1 = moneyInput.Length;
                    string lastNum = "";
                    while (moneyInput[count1] != '+')
                    {
                        numStack.Push(moneyInput[count1]);
                        count1--;
                    }
                    while (numStack.Count != 0)
                    {
                        lastNum += numStack.Peek();
                        numStack.Pop();
                    }
                    typeOfMoney += Convert.ToDouble(lastNum);
                    check = true;
                }
            } while (!check);
        }

        public override double salaryCalculating() => 0.6 * m_receiptMoney + m_tipsMoney;

        public override double getIncomeMoney() => m_receiptMoney;
    }
}

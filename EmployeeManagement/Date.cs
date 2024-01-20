using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class Date
    {
        string m_paidDate;
        double m_paidSalary;
        double m_incomeMoney;

        public string PaidDate
        {
            get => m_paidDate;
            set => m_paidDate = value;
        }

        public double PaidSalary
        {
            get => m_paidSalary;
            set => m_paidSalary = value;
        }

        public double IncomeMoney
        {
            get => m_incomeMoney; 
            set => m_incomeMoney = value;
        }
    }
}

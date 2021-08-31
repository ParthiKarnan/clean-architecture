using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocieteGenerale.Domain.Common
{

    public static class ExtensionHelper
    {
        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
        public static decimal RateOfInterestCalculationByAmountAndItsDuration(DateTime invoiceDate, decimal amount)
        {
            decimal totalAmount = 0;

            DateTime start = invoiceDate;
            DateTime end = DateTime.Now;
            TimeSpan timeSpan = end - start;
            int duration = timeSpan.Days;

            if (duration <= 14)
            {
                decimal inerest = 4;
                decimal interestAmount = amount * (inerest / 100);
                totalAmount = amount + interestAmount;
            }
            else if (duration > 14 && duration <= 30)
            {
                decimal inerest = 6;
                decimal interestAmount = amount * (inerest / 100);
                totalAmount = amount + interestAmount;
            }
            else if (duration > 30 && duration <= 60)
            {
                decimal inerest = 10;
                decimal interestAmount = amount * (inerest / 100);
                totalAmount = amount + interestAmount;
            }
            else if (duration > 60 && duration <= 180)
            {
                decimal inerest = 16;
                decimal interestAmount = amount * (inerest / 100);
                totalAmount = amount + interestAmount;
            }
            else if (duration > 180)
            {
                decimal inerest = 20;
                decimal interestAmount = amount * (inerest / 100);
                totalAmount = amount + interestAmount;
            }
            return totalAmount;
        }
    }
}
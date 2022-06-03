using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._01._2022.ClassHelper
{
    internal class Calculations
    {
        public static decimal CostOfRent(DateTime dateOfBegin,DateTime dateOfEnd, decimal Cost)
        {
            return (dateOfEnd.DayOfYear-dateOfBegin.DayOfYear)*Cost;
        }
    }
}

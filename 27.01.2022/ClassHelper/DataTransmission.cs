using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._01._2022.ClassHelper
{
    internal class DataTransmission
    {
        public static EF.Client GetClient { get; set; }

        public static EF.Employee GetEmployee { get; set; }

        public static EF.Product GetProduct { get; set; }
    }
}

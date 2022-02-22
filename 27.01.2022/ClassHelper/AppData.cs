using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._01._2022.ClassHelper
{
   public class AppData
   {
     public static EF.Entities Context { get; } = new EF.Entities();
    }
}

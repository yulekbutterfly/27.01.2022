using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Windows;

namespace _27._01._2022.ClassHelper
{
  
    
        public class ValidationResult
        {



            public static bool ValidationPassword(string password)
            {
                if (string.IsNullOrWhiteSpace(password) || password == "")
                    return false;
                if (password.Length < 8 || password.Length > 20)
                    return false;
                if (!password.Any(Char.IsUpper))
                    return false;
                if (!password.Any(Char.IsLower))
                    return false;
                if (!password.Any(Char.IsDigit))
                    return false;
                if (!password.Any(Char.IsPunctuation))
                    return false;

                for (int i = 0; i < password.Length; i++)
                {
                    if (password[i] == ' ')
                        return false;
                }
                return true;
            }

            public static bool ValidationLogin(string login)
            {
                if (login.Length < 2 || login.Length > 50 || string.IsNullOrWhiteSpace(login))
                    return false;

                if (AppData.Context.Employee.Where(i => i.Login == login).FirstOrDefault() != null)
                {
                    return false;

                }
                return true;

            }
            public static bool ValidationDateOfBirth(DateTime dateofbirth)
            {
                if (dateofbirth >= DateTime.Now.Date)
                {
                    return false;
                }
                return true;
            }

            public static bool ValidationPhone(string num)

            {
            string Symbs = "!\"#$%&'()*+,-./;:<=>?@[\\]:_{|} ";
            if (num.IndexOfAny(Symbs.ToCharArray()) >= 0)
            {
                return false;

            }
            if (string.IsNullOrWhiteSpace(num) || num == "")
            {
                return false;
            }
            if (num.Length !=11)
            {
                return false;
            }
           
            return true;
        }

            public static bool ValidationNameLNameMName(string namelnamemname)
            {
                string Symbs = "!\"#$%&'()*+,-./::<=>?@[\\]:_{|}0123456789 ";
                char[] chars = Symbs.ToCharArray();
                if (namelnamemname.IndexOfAny(chars) >= 0)
                {
                    return false;

                }
                if (string.IsNullOrWhiteSpace(namelnamemname) || namelnamemname == "")
                {
                    return false;
                }
                else if (namelnamemname.Length < 2 || namelnamemname.Length > 50)
                {
                    return false;
                }                
                
                return true;
            }

            
            

        }
    

}

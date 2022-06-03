using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static _27._01._2022.ClassHelper.ValidationResult;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidationPassword_CorrectPassword_returnTrue()
        {
            //arrange 

            string password = "Watermelon123!";
            bool ex = true;

            //act 

            bool result = ValidationPassword(password);

            //assert 

            Assert.AreEqual(ex, result);
        }


        [TestMethod]
        public void ValidationLogin_SOOOO_HUGE_returnFalse()
        {
            //arrange

            string login = "DORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIMEDORIME";
            bool ex = false;

            //act

            bool result = ValidationLogin(login);

            //assert

            Assert.AreEqual(ex, result);
        }

        [TestMethod]
        public void ValidationPhone_NotNumberSymbols_returnFalse()
        {
            //arrange

            string num = "NoNumber??";
            bool ex = false;

            //act 

            bool result = ValidationPhone(num);

            //assert 

            Assert.AreEqual(ex, result);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Task1_Currency;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyTaskTests
{

    [TestClass]
    public class UnitTest2 //CurrencyStorage
    {

        [TestMethod]
        public void TestSelectUAH()
        {
            bool exp = false;


            CurrencyStorage c = new CurrencyStorage();
            c.Read("tets.txt");
            bool actual = c.SelectUAH();

            Assert.AreEqual(exp, actual);
           
        }

    }
}
    


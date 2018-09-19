using System;
using Task1_Currency;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyTaskTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestClass]
        public class CurrencyTest
        {
            [TestMethod]
            public void Currencytest()
            {
                string currencyNameexp = "USD";

                float amountexp = 10;

                Currency c = new Currency(currencyNameexp, amountexp);

                Assert.AreEqual(amountexp, c.Amount);
                Assert.AreEqual(currencyNameexp, c.CurrencyName);
            }
        }

    }
}

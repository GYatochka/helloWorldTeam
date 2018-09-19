using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1_Currency.Test
{
    [TestClass]
    public class CurrencyTest
    {
        [TestMethod]
        public void Currencytest()
        {
            string currencynameexp = "USD";
            float amountexp = 10;

            Currency c = new Currency(currencynameexp, amountexp);

            Assert.AreEqual(amountexp, c.Amount);
            Assert.AreEqual(currencynameexp, c.CurrencyName);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1_Currency.Tests
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
        [TestMethod]
        public 
    }

}

/*   
        public Currency()
        {
            _amount = 0;
            _currencyName = "UAH";
        }
        public Currency(string currencyName, float amount)
        {
            Amount = amount;
            _currencyName = currencyName;
        }

}*/

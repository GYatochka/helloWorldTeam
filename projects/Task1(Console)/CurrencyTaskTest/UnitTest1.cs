using System;
using Task1_Currency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CurrencyTaskTest
{
    using System.IO;
    using System.Linq;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CurrencyParamConstructorTest()
        {
            string currencyNameexp = "USD";

            float amountexp = 10;

            Currency c = new Currency(currencyNameexp, amountexp);

            Assert.AreEqual(amountexp, c.Amount);
            Assert.AreEqual(currencyNameexp, c.CurrencyName);
        }
        [TestMethod]
        public void CurrencyEmptyConstructorTest()
        {


            Currency c = new Currency();

            Assert.AreEqual(0, c.Amount);
            Assert.AreEqual("UAH", c.CurrencyName);
        }

        [TestMethod]
        public void TestSelectUAH()
        {
            CurrencyStorage c = new CurrencyStorage();
            c.Read("doc.txt");
            bool actual = c.SelectUAH();

            Assert.IsTrue( actual);

        }

        [TestMethod]
        public void DictionaryTest()
        {

            CurrencyStorage c = new CurrencyStorage();
            c.Read("doc.txt");
            Dictionary<string, float> currencies = new Dictionary<string, float>();
            currencies = c.TotalNumAndCurrName("task_3_doc.txt");
            Assert.AreEqual("UAH",currencies.First().Key);
            Assert.AreEqual(592, currencies.First().Value);
        }

        [TestMethod]
        public void OutputTest()
        {
            CurrencyStorage c = new CurrencyStorage();
            c.Read("doc.txt");
            Assert.IsTrue(c.output());
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadTest()
        {
            List<float> l = new List<float>();
            CurrencyStorage st = new CurrencyStorage();
            st.Read(("abc"));
        }
    }
}

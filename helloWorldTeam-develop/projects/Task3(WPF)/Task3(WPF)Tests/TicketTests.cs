using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_WPF_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

namespace Task3_WPF_.Tests
{
    [TestClass()]
    public class TicketTests
    {
        [TestMethod()]
        public void ProductConstructor()
        {
            Product obj = new Product();
            Assert.AreEqual(0, obj.Price);
            Assert.AreEqual(1, obj.Quantity);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ProductExceprionTest()
        {
            Product obj = new Product();
            obj.Price = -1;
        }

        [TestMethod()]
        public void ReadFromFile()
        {
            FileDataChange obj = new FileDataChange();
            ObservableCollection<Product> SushiesList = new ObservableCollection<Product>();
            SushiesList = obj.ReadFromFile();
            Assert.AreEqual("Bogodashi", SushiesList[0].Name);
            Assert.AreEqual(69, SushiesList[0].Price);
        }

        [TestMethod()]
        public void WriteToFile()
        {
            FileDataChange obj = new FileDataChange();
            ObservableCollection<Product> SushiesList = new ObservableCollection<Product>();
            SushiesList = obj.ReadFromFile();
            bool actual = obj.WriteToFile("natasha", 80, SushiesList);
            bool flag = true;
            if (new FileInfo("ticket.txt").Length == 0) { flag = false; }
            Assert.AreEqual(flag, actual);
        }

        [TestMethod()]
        public void TicketDefaultConstructorTest()
        {
            Ticket obj = new Ticket();
            Assert.AreEqual("0", obj.TotalSumText);
            Assert.AreEqual("1", obj.ProductAmount);
        }

        [TestMethod()]
        public void GetCashierTest()
        {
            Assert.AreEqual("Natasha", Ticket.Cashier);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetChangedCashierTest()
        {
            Ticket.Cashier = "Oleg";
            Assert.AreEqual("Oleg", Ticket.Cashier);
        }
    }
}
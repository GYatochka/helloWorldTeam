using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_WPF_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Data.Entity;
namespace Task3_WPF_.Tests
{/// <summary>
/// клас з тестами
/// </summary>
    [TestClass()]
    public class TicketTests
    {
        /// <summary>
        /// default product constructor check
        /// </summary>
        [TestMethod()]
        public void ProductConstructor()
        {
            Product obj = new Product();
            Assert.AreEqual(0, obj.Price);
            Assert.AreEqual(1, obj.Quantity);
        }

        /// <summary>
        /// check if price in default constructor is not set to negative number
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ProductExceprionTest()
        {
            Product obj = new Product();
            obj.Price = -1;
        }

     
        /// <summary>
        /// default constructor of class ticket
        /// </summary>
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

        /// <summary>
        /// get list of products test
        /// </summary>
        [TestMethod()]
        public void GetData()
        {
            List<Product> p = (WorkWithData.GetProducts()).ToList<Product>();
            Assert.AreEqual("avocadoSplash", p[0].Name);
            Assert.AreEqual(1, p[0].Quantity);
            Assert.AreEqual(13, p[0].Price);
        }

        /// <summary>
        /// check whether ticket with orders is added to database
        /// </summary>
        [TestMethod()]
        public void AddCheck()
        {
            ObservableCollection<Product> p = new ObservableCollection<Product>();
            Product pr = new Product();
            pr.Name = "avocadoSplash";
            pr.Price = 13;
            pr.Quantity = 1;
            p.Add(pr);
            pr.Name = "Unagi";
            pr.Price = 40;
            pr.Quantity = 1;
            p.Add(pr);
            float sum =(p[0].Price + p[1].Price);
            WorkWithData.WriteCheckInDB("natasha", sum, p);
            UnitOfWork un = new UnitOfWork();
            int id = 0;
            var cheks = un.Checks.GetAll();
            List<Check> l = new List<Check>();
            Assert.IsTrue(cheks.Count() != 0);
            bool flag = false;
            foreach (Check u in cheks)
            {
                l.Add(u);
            }
            foreach (Check u in l)
            {
                if (u.Cashier == "natasha"  )
                {
                    flag = true;
                    id = u.Id;
                }
            }
            Assert.IsTrue(flag);


        }

        /// <summary>
        /// new product addition
        /// </summary>
        [TestMethod()]
        public void AddProduct()
        {
            Product p = new Product();
            p.Name = "ivasi";
            p.Price = 5;
            p.Quantity = 1;

            UnitOfWork un = new UnitOfWork();
            un.Products.Create(p);

            p.Price = 8;
            var pr = un.Products.GetAll();
            List<Product> l = new List<Product>();
            Assert.IsTrue(pr.Count() != 0);
            foreach (Product u in pr)
            {
                l.Add(u);
            }

            foreach (Product u in l)
            {
                if(u.Name=="ivasi")
                Assert.AreEqual(8, u.Price);
            }
        }

        /// <summary>
        /// product delete check
        /// </summary>
        [TestMethod]
        public void DeleteProduct()
        {
            UnitOfWork un = new UnitOfWork();
            Product p = un.Products.GetById("ivasi");
            bool flag = true;
            un.Products.DeleteById("ivasi");
            foreach(Product u in un.Products.GetAll())
            {
                if(u.Name=="ivasi")
                {
                    flag = false;
                }
            }
            Assert.IsTrue(flag);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task3_WPF_
{
   /// <summary>
   /// клас для доступу до даних
   /// </summary>
  public class WorkWithData
    {
    /// <summary>
    /// метод отримання продуктів із БД
    /// </summary>
    /// <returns></returns>
        public static  ObservableCollection<Product> GetProducts()
        {
            ProductContext db = new ProductContext();
            UnitOfWork un = new UnitOfWork();


            var products = un.Products.GetAll();
            ObservableCollection<Product> l = new ObservableCollection<Product>();
            foreach (Product u in products)
            {
                l.Add(u);
            }
           
            return l;
        }
        /// <summary>
        /// метод запису чеків в БД
        /// </summary>
        /// <param name="cashier"></param>
        /// <param name="calculatedSum"></param>
        /// <param name="SushiesList"></param>
        static public void WriteCheckInDB(string cashier,float calculatedSum, ObservableCollection<Product> SushiesList)
        {
            Check check = new Check();
            check.Cashier = cashier;


            string details = "";
           
            for (int i = 0; i < SushiesList.Count; i++)
            {
                details += (SushiesList[i].ToString() + " || ");
            }
        
         
            check.Details = details;
            check.Sum= calculatedSum ;
            UnitOfWork u = new UnitOfWork();
            u.Checks.Create(check);
            u.Checks.Save();
        }

    }
}

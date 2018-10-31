using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Task3_WPF_
{
    public class FileDataChange
    {
        private Product p;
        private string _ticketName;
        public FileDataChange() { _ticketName = "Ticket"; }

        /// <summary>
        /// Метод для зчитування даних із файлу.
        /// </summary>
        /// <param name="SushiesList"></param>
        public ObservableCollection<Product> ReadFromFile( ObservableCollection<Product> SushiesList)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("sushiList.txt");
            string line;
            SushiesList = new ObservableCollection<Product>();
            while ((line = file.ReadLine()) != null)
            {
                p = new Product();
                string[] vars = line.Split(' ');
                p.Name = vars[0];
                p.Price = (float)Convert.ToDouble(vars[1]);
                SushiesList.Insert(0,p);
            }

            file.Close();
            return SushiesList;
        }
        /// <summary>
        /// Метод, для вводу даних чека у файл.
        /// </summary>
        /// <param name="cashier">
        /// Ім'я касира, що буде написано на чеку.
        /// </param>
        /// <param name="calculatedSum">
        /// Загальна ціна замовлення.
        /// </param>
        /// <param name="SushiesList">
        /// Список замовлених суші.
        /// </param>
        public void WriteToFile(string cashier, float calculatedSum, ObservableCollection<Product> SushiesList)
        {      
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_ticketName+".txt"), true))
            {
                outputFile.WriteLine("=====================================");
                for (int i = 0; i < SushiesList.Count; i++)
                {
                    outputFile.WriteLine(SushiesList[i].ToString());
                }
                outputFile.WriteLine("Cashier: " + cashier);
                outputFile.WriteLine('\t');
                outputFile.WriteLine("TOTAL SUM: " + calculatedSum);
                outputFile.WriteLine("=====================================");
            }
            
        }
    }
}

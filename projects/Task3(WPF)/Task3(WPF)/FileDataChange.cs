using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3_WPF_
{
    public class FileDataChange
    {
        private Ticket obj;
        private Product p;
        private string ticket_name;
        public FileDataChange() { obj = new Ticket(); ticket_name = "ticket"; }

        public void ReadFromFile()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("sushiList.txt");
            string line;
           
            while ((line = file.ReadLine()) != null)
            {
                p = new Product();
                string[] vars = line.Split(' ');
                p.Name = vars[0];
                p.Price = (float)Convert.ToDouble(vars[1]);
                obj.SushiesList.Add(p);
            }

            file.Close();
        }

        public void WriteToFile()
        {
            ticket_name = ticket_name + ".txt";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(ticket_name), true))
            {
                outputFile.WriteLine("=====================================");
                for (int i = 0; i < obj.SushiesList.Count; i++)
                {
                    outputFile.WriteLine(obj.SushiesList[i]);
                }
                outputFile.WriteLine("Cashier: " + obj.Cashier);
                outputFile.WriteLine("TOTAL SUM: " + obj.calculateTotalSum());

                outputFile.WriteLine("=====================================");
            }
            
        }
    }
}

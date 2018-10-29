using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3_WPF_
{
    class FileDataChange
    {
        private Ticket obj;
        private Product p;
        private string ticket_name;
        private int count;
        FileDataChange() { obj = new Ticket(); p = new Product(); ticket_name = "ticket"; count = 0; }

        public void ReadFromFile()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("sushiList.txt");
            string line;
           
            while ((line = file.ReadLine()) != null)
            {
                string[] vars = line.Split(' ');
                p.Name = vars[0];
                p.Price = (float)Convert.ToDouble(vars[1]);
                obj.Sushies.Add(p);
            }

            file.Close();
        }

        public void WriteToFile()
        {
            ticket_name = ticket_name + count + ".txt";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(ticket_name), true))
            {
                outputFile.WriteLine("=====================================");
                for (int i = 0; i < obj.Sushies.Count; i++)
                {
                    outputFile.WriteLine(obj.Sushies[i]);
                }

                outputFile.WriteLine("TOTAL SUM: " + obj.calculateTotalSum());

                outputFile.WriteLine("=====================================");
            }
            count++;
        }
    }
}

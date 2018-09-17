using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_Currency;

namespace Task1_Currency
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                //write program logic after finishing class logic

                CurrencyStorage obj = new CurrencyStorage();
                Dictionary<string, float> currencies;
                obj.Read("doc.txt");
                obj.output();
                Console.WriteLine();
                obj.SelectUAH();
                Console.WriteLine();
            }
            // add other needed exceptions 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}

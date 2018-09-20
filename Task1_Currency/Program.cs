using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Task1_Currency;
using System.Data;
using System.IO;

namespace Task1_Currency
{


    class Program
    {

        public static void WriteErrorsInFiles(Exception e)
        {
            int code = 0;
            using (StreamWriter output = new StreamWriter(Path.Combine("log.txt"), true))
            {
                output.WriteLine("["+ DateTime.Now+"]"+ " " +e.Message);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                //write program logic after finishing class logic               
                CurrencyStorage obj = new CurrencyStorage();
                Dictionary<string, float> currencies;
                obj.Read("doc1.txt");
                obj.output();
                Console.WriteLine();
                bool f = obj.SelectUAH();
                Console.WriteLine();
                currencies = obj.TotalNumAndCurrName("task_3_doc.txt");
                CurrencyConverter.Convert(currencies, "task_4_doc.txt");
            }
            // add other needed exceptions 
            catch (FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message);
                WriteErrorsInFiles((fe));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                WriteErrorsInFiles((e));
            }
            finally
            {
                Console.WriteLine("Now you can close the program!");
            }

            Console.ReadLine();
        }



    }
}

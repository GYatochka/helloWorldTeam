using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Task4_ADO.NET_
{

    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=NORTHWIND; Integrated Security=True";
            SqlConnection connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                PrintInfo(connection);
                SELECTCommandReader("SELECT * FROM Employees ", connection);

            }


            catch (Exception e)
            {
                Console.Write(e.Message);

            }
            finally
            {
                connection.Close();

            }
            Console.ReadKey();
        }
        static void PrintInfo(SqlConnection connection)
        {
            Console.WriteLine("Connection to: ");
            Console.WriteLine("Data source: " + connection.DataSource);
            Console.WriteLine("Data base: " + connection.Database);
            Console.WriteLine("State: " + connection.State);

        }
        static void SELECTCommand(string commandStr, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = commandStr;
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(command.CommandText, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);




            Console.WriteLine();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Rows[i].ItemArray.Count(); j++)
                {
                    Console.Write(ds.Tables[0].Columns[j] + ": ");
                    Console.WriteLine(ds.Tables[0].Rows[i].ItemArray[j] + "  ");

                }

                Console.WriteLine("==========================================================================================");
            }
        }
        static void SELECTCommandReader(string commandStr, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = commandStr;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            string dividation = "===================";
            Console.WriteLine();
          while( reader.Read())
            {
                for(int i=0;i<reader.FieldCount;i++)
                {
                    Console.Write(reader.GetName(i) + ": ");
                    Console.WriteLine(reader.GetValue(i));
                }
                Console.WriteLine(dividation);

            }



        }
    }

    }


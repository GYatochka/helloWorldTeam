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
                //1
                SELECTCommandReader("select * from employees where EmployeeId = 8", connection);
                //2
                SELECTCommandReader("select LastName, FirstName from Employees where City = 'London'", connection);
                //3
                SELECTCommandReader("select LastName, FirstName from Employees  where FirstName LIKE 'A%'", connection);
                //4
                SELECTCommandReader("SELECT DATEDIFF(yy,BirthDate,getdate()) AS 'Age In Years', LastName, FirstName" +
                                    " FROM Employees where DATEDIFF(yy,BirthDate,getdate())  > 55 Order by LastName", connection);
                //5
                SELECTCommandReader("select count(EmployeeID) as 'Live in London' from Employees where City='London'", connection);
                //6
                SELECTCommandReader("select Min( DATEDIFF(yy,BirthDate,getdate())) as 'min age', Max( DATEDIFF(yy,BirthDate,getdate())) as 'max age', " +
                                    "avg( DATEDIFF(yy,BirthDate,getdate())) as 'avg age' from Employees where city='London'", connection);
				//7
                 SELECTCommandReader("select Min( DATEDIFF(yy,BirthDate,getdate())) as 'min age', Max( DATEDIFF(yy,BirthDate,getdate())) as 'max age', " +
                                     "avg( DATEDIFF(yy,BirthDate,getdate())) as 'avg age', City from Employees group by City", connection);
                 //8
                 SELECTCommandReader("select avg( DATEDIFF(yy,BirthDate,getdate())) as 'avg age', City from Employees" +
                                     " group by City having avg( DATEDIFF(yy,BirthDate,getdate())) > 60 ", connection);
                 //9
                 SELECTCommandReader("Select LastName, FirstName from Employees" +
                                     " where  DATEDIFF(yy,BirthDate,getdate()) = (select Max( DATEDIFF(yy,BirthDate,getdate())) from Employees)", connection);
                 //10
                 SELECTCommandReader("Select top 3 LastName,  FirstName,  DATEDIFF(yy,BirthDate,getdate()) as 'age' from Employees " +
                                     "order by DATEDIFF(yy,BirthDate,getdate()) desc ", connection);
                 //11          
                 SELECTCommandReader("select distinct City from Employees", connection);
                 //12
                 SELECTCommandReader("select FirstName, LastName, BirthDate from Employees" +
                                     " where Month(BirthDate) =  Month(getdate())", connection); //1", connection);
                //13                                                                              
                SELECTCommandReader("select distinct FirstName, LastName from Employees " +
                                    "inner join Orders on Employees.EmployeeID = Orders.EmployeeID where ShipCity = 'Madrid'", connection);
                //14
                SELECTCommandReader("select distinct  FirstName, LastName, count(OrderID) as 'Number of orders' from Employees " +
                                    "left join  Orders on Employees.EmployeeID = Orders.EmployeeID where  YEAR(ShippedDate) = 1997 group by FirstName, LastName", connection);
                //15
                SELECTCommandReader("select distinct  FirstName, LastName, count(OrderID) as 'Number of orders' from Employees " +
                                    "inner join  Orders on Employees.EmployeeID = Orders.EmployeeID where  YEAR(ShippedDate) = 1997 group by FirstName, LastName", connection);
                //16
                SELECTCommandReader("select distinct  FirstName, LastName, count(OrderID) as 'Number of orders' from Employees " +
                                    "left join  Orders on Employees.EmployeeID = Orders.EmployeeID where  YEAR(ShippedDate) = 1997 and " +
                                    "Orders.ShippedDate > Orders.RequiredDate group by FirstName, LastName", connection);
                //17
                SELECTCommandReader("select count(OrderID) as 'France costumers' from Orders " +
                                    "inner join Customers on Orders.CustomerID = Customers.CustomerID where Customers.Country = 'France'", connection);
                //18
                SELECTCommandReader("select Customers.ContactName, count(Orders.OrderID) as 'Orders' from Customers " +
                                    "inner join Orders on Customers.CustomerID = Orders.CustomerID where Customers.Country = 'France' " +
                                    "group by Customers.ContactName having count(Orders.OrderID) > 1 ", connection);
                //19
                SELECTCommandReader("select Customers.ContactName, count(Orders.OrderID) as 'Orders' from Customers " +
                                    "inner join Orders on Customers.CustomerID = Orders.CustomerID where Customers.Country = 'France' " +
                                    "group by Customers.ContactName having count(Orders.OrderID) > 1 ", connection);

                //20
                SELECTCommandReader("SELECT DISTINCT CompanyName FROM Customers,Orders,OrderDetails " +
                                    "WHERE OrderDetails.ProductID=14 AND  Orders.CustomerID = Customers.CustomerID AND" +
                                    " OrderDetails.OrderID = Orders.OrderID", connection);
                //21
                SELECTCommandReader("SELECT DISTINCT CompanyName, OrderDetails.Quantity, OrderDetails.Quantity*OrderDetails.UnitPrice as Sum FROM Customers,Orders,OrderDetails " +
                                    "WHERE OrderDetails.ProductID=14 AND  Orders.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID", connection);
                //22
                //SELECTCommandReader("", connection);
                //23
                SELECTCommandReader("SELECT DISTINCT Customers.CompanyName FROM Customers,Orders,OrderDetails,Suppliers,Products" +
                                    " WHERE Customers.Country='France'AND OrderDetails.ProductID=Products.ProductID AND " +
                                    " Orders.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID AND " +
                                    "Products.SupplierID=Suppliers.SupplierID AND Suppliers.Country!='France'", connection);

                //24
                SELECTCommandReader("SELECT DISTINCT Customers.CompanyName FROM Customers,Orders,OrderDetails,Suppliers,Products" +
                                    " WHERE Customers.Country='France'AND OrderDetails.ProductID=Products.ProductID AND " +
                                    " Orders.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID AND" +
                                    " Products.SupplierID=Suppliers.SupplierID AND Suppliers.Country='France'", connection);
				
				 //25
                 SELECTCommandReader("SELECT Customers.Country,SUM(OrderDetails.UnitPrice) as Sum FROM Customers,OrderDetails,Orders " +
                                     "WHERE   Orders.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID  " +
                                     "GROUP BY  Customers.Country  ", connection);
                  //26
                 SELECTCommandReader("SELECT Customers.Country, SUM(OrderDetails.UnitPrice) as Sum, " +
                                     "56500.9100 - SUM(OrderDetails.UnitPrice) as NondomesticSum  FROM Customers, OrderDetails, Orders " +
                                     "WHERE   Orders.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID  " +
                                     "GROUP BY  Customers.Country  ", connection);
                 //27
                 SELECTCommandReader("SELECT Categories.CategoryName, SUM(OrderDetails.UnitPrice) FROM Categories, OrderDetails, Orders " +
                                     "WHERE OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate > '1998.01.01' AND Orders.OrderDate < '1998.12.31' " +
                                     "GROUP BY Categories.CategoryName", connection);
                 //28
                 SELECTCommandReader("select distinct ProductName, x.UnitPrice from Products" +
                                     " inner join (select ShippedDate, ProductID , UnitPrice from Orders " +
                                     "inner join OrderDetails on Orders.OrderID = OrderDetails.OrderID ) as x on" +
                                     " Products.ProductID = x.ProductID", connection);
                //29
                SELECTCommandReader("select a.Title, b.EmployeeID from Employees as a left join Employees as b on a.EmployeeID = b.EmployeeID", connection);
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
            reader.Close();
        }
    }
}


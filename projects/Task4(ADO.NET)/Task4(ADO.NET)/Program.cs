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
                CommandReader("select * from employees where EmployeeId = 8", connection,1);
                //2
                CommandReader("select LastName, FirstName from Employees where City = 'London'", connection,2);
                //3
                CommandReader("select LastName, FirstName from Employees  where FirstName LIKE 'A%'", connection,3);
                //4
                CommandReader("SELECT DATEDIFF(yy,BirthDate,getdate()) AS 'Age In Years', LastName, FirstName" +
                                    " FROM Employees where DATEDIFF(yy,BirthDate,getdate())  > 55 Order by LastName", connection,4);
                //5
                CommandReader("select count(EmployeeID) as 'Live in London' from Employees where City='London'", connection,5);
                //6
                CommandReader("select Min( DATEDIFF(yy,BirthDate,getdate())) as 'min age', Max( DATEDIFF(yy,BirthDate,getdate())) as 'max age', " +
                                    "avg( DATEDIFF(yy,BirthDate,getdate())) as 'avg age' from Employees where city='London'", connection,6);
				//7
                 CommandReader("select Min( DATEDIFF(yy,BirthDate,getdate())) as 'min age', Max( DATEDIFF(yy,BirthDate,getdate())) as 'max age', " +
                                     "avg( DATEDIFF(yy,BirthDate,getdate())) as 'avg age', City from Employees group by City", connection,7);
                 //8
                 CommandReader("select avg( DATEDIFF(yy,BirthDate,getdate())) as 'avg age', City from Employees" +
                                     " group by City having avg( DATEDIFF(yy,BirthDate,getdate())) > 60 ", connection,8);
                 //9
                 CommandReader("Select LastName, FirstName from Employees" +
                                     " where  DATEDIFF(yy,BirthDate,getdate()) = (select Max( DATEDIFF(yy,BirthDate,getdate())) from Employees)", connection,9);
                 //10
                 CommandReader("Select top 3 LastName,  FirstName,  DATEDIFF(yy,BirthDate,getdate()) as 'age' from Employees " +
                                     "order by DATEDIFF(yy,BirthDate,getdate()) desc ", connection,10);
                 //11          
                 CommandReader("select distinct City from Employees", connection,11);
                 //12
                 CommandReader("select FirstName, LastName, BirthDate from Employees" +
                                     " where Month(BirthDate) =  Month(getdate())", connection,12); //1", connection);
                //13                                                                              
                CommandReader("select distinct FirstName, LastName from Employees " +
                                    "inner join Orders on Employees.EmployeeID = Orders.EmployeeID where ShipCity = 'Madrid'", connection,13);
                //14
                CommandReader("select distinct  FirstName, LastName, count(OrderID) as 'Number of orders' from Employees " +
                                    "left join  Orders on Employees.EmployeeID = Orders.EmployeeID where  YEAR(ShippedDate) = 1997 group by FirstName, LastName", connection,14);
                //15
                CommandReader("select distinct  FirstName, LastName, count(OrderID) as 'Number of orders' from Employees " +
                                    "inner join  Orders on Employees.EmployeeID = Orders.EmployeeID where  YEAR(ShippedDate) = 1997 group by FirstName, LastName", connection,15);
                //16
                CommandReader("select distinct  FirstName, LastName, count(OrderID) as 'Number of orders' from Employees " +
                                    "left join  Orders on Employees.EmployeeID = Orders.EmployeeID where  YEAR(ShippedDate) = 1997 and " +
                                    "Orders.ShippedDate > Orders.RequiredDate group by FirstName, LastName", connection,16);
                //17
                CommandReader("select count(OrderID) as 'France costumers' from Orders " +
                                    "inner join Customers on Orders.CustomerID = Customers.CustomerID where Customers.Country = 'France'", connection,17);
                //18
                CommandReader("select Customers.ContactName, count(Orders.OrderID) as 'Orders' from Customers " +
                                    "inner join Orders on Customers.CustomerID = Orders.CustomerID where Customers.Country = 'France' " +
                                    "group by Customers.ContactName having count(Orders.OrderID) > 1 ", connection,18);
                //19
                CommandReader("select Customers.ContactName, count(Orders.OrderID) as 'Orders' from Customers " +
                                    "inner join Orders on Customers.CustomerID = Orders.CustomerID where Customers.Country = 'France' " +
                                    "group by Customers.ContactName having count(Orders.OrderID) > 1 ", connection,19);

                //20
                CommandReader("SELECT DISTINCT CompanyName FROM Customers,Orders,OrderDetails " +
                                    "WHERE OrderDetails.ProductID=14 AND  Orders.CustomerID = Customers.CustomerID AND" +
                                    " OrderDetails.OrderID = Orders.OrderID", connection,20);
                //21
                CommandReader("SELECT DISTINCT CompanyName, OrderDetails.Quantity, OrderDetails.Quantity*OrderDetails.UnitPrice as Sum FROM Customers,Orders,OrderDetails " +
                                    "WHERE OrderDetails.ProductID=14 AND  Orders.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID", connection,21);
                //22
                //CommandReader("", connection);
                //23
                CommandReader("SELECT DISTINCT Customers.CompanyName FROM Customers,Orders,OrderDetails,Suppliers,Products" +
                                    " WHERE Customers.Country='France'AND OrderDetails.ProductID=Products.ProductID AND " +
                                    " Orders.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID AND " +
                                    "Products.SupplierID=Suppliers.SupplierID AND Suppliers.Country!='France'", connection,23);

                //24
                CommandReader("SELECT DISTINCT Customers.CompanyName FROM Customers,Orders,OrderDetails,Suppliers,Products" +
                                    " WHERE Customers.Country='France'AND OrderDetails.ProductID=Products.ProductID AND " +
                                    " Orders.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID AND" +
                                    " Products.SupplierID=Suppliers.SupplierID AND Suppliers.Country='France'", connection,24);
				
				 //25
                 CommandReader("SELECT Customers.Country,SUM(OrderDetails.UnitPrice) as Sum FROM Customers,OrderDetails,Orders " +
                                     "WHERE   Orders.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID  " +
                                     "GROUP BY  Customers.Country  ", connection,25);
                  //26
                 CommandReader("SELECT Customers.Country, SUM(OrderDetails.UnitPrice) as Sum, " +
                                     "56500.9100 - SUM(OrderDetails.UnitPrice) as NondomesticSum  FROM Customers, OrderDetails, Orders " +
                                     "WHERE   Orders.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID  " +
                                     "GROUP BY  Customers.Country  ", connection,26);
                 //27
                 CommandReader("SELECT Categories.CategoryName, SUM(OrderDetails.UnitPrice) FROM Categories, OrderDetails, Orders " +
                                     "WHERE OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate > '1998.01.01' AND Orders.OrderDate < '1998.12.31' " +
                                     "GROUP BY Categories.CategoryName", connection,27);
                 //28
                 CommandReader("select distinct ProductName, x.UnitPrice from Products" +
                                     " inner join (select ShippedDate, ProductID , UnitPrice from Orders " +
                                     "inner join OrderDetails on Orders.OrderID = OrderDetails.OrderID ) as x on" +
                                     " Products.ProductID = x.ProductID", connection,28);
                //29
                CommandReader("select a.Title, b.EmployeeID from Employees as a left join Employees as b on a.EmployeeID = b.EmployeeID", connection,29);
                //30
                CommandReader("select distinct City from (select Customers.City from Customers" +
                                    " inner join Employees on Customers.City = Employees.City) as x " +
                                    "inner join Orders on x.City = Orders.ShipCity", connection,30);
                //31
                CommandReader("INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
                                    " VALUES('Ivanov', 'Ivan', '1999.08.01', '2018.08.01', 'Hrubenka,5', 'Kiyv', 'Ukraine', 'Zahirnuy Bohdan')," +
                                    "('Petrenko', 'Petro', '1999.07.21', '2018.05.11', 'Kaprenka,21', 'Kiyv', 'Ukraine', 'Pankovec Zlata')," +
                                    "('Makliuk', 'Maria', '1979.05.10', '2002.06.12', 'Rudenka,48', 'Lviv', 'Ukraine', 'Benko Muhailo')," +
                                    "('Dankevuch', 'Andriy', '1987.01.09', '2005.09.06', 'Svobodu,8', 'Chernivci', 'Ukraine', 'Pankovec Zlata')," +
                                    "('Tarekaniuk', 'Petro', '1996.11.02', '2018.10.11', 'Vasuliuka,26', 'Kiyv', 'Ukraine', 'Zahirnuy Bohdan')", connection,31);
                //32
                CommandReader("SELECT * FROM Employees WHERE Country = 'Ukraine'", connection,32);
                //33
                CommandReader("UPDATE Employees SET City = 'IvanoFrankivsk' WHERE FirstName = 'Andriy'", connection,33);
                //34
                CommandReader("UPDATE Employees SET HireDate = GETDATE()", connection,34);
                //35
                CommandReader("DELETE FROM Employees WHERE FirstName = 'Andriy'", connection,35);
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
      
        static void CommandReader(string commandStr, SqlConnection connection,int task)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = commandStr;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            string dividation = "========= " + task + " =========";
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Task3_WPF_
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("SushiBarDB")
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}

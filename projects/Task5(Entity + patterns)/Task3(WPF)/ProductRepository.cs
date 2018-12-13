using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Task3_WPF_
{
    /// <summary>
    ///realisation of interface Irepositoy in this class
    /// </summary>
    public class ProductRepository : IRepository<Product>
    {
        private ProductContext db;

        public ProductRepository(ProductContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product GetById(string sushi_name)
        {
            return db.Products.Find(sushi_name);
        }

        public void Create(Product p)
        {
            db.Products.Add(p);
        }

        public void Update(Product p)
        {
            db.Entry(p).State = EntityState.Modified;
        }

        public void DeleteById(string sushi_name)
        {
            Product p = db.Products.Find(sushi_name);
            if (p != null)
                db.Products.Remove(p);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        //private bool disposed = false;

        /*public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }*/
    }
}

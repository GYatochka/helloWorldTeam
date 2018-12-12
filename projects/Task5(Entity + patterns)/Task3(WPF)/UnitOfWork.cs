using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_WPF_
{
    class UnitOfWork : IDisposable
    {
        private ProductContext db = new ProductContext(); 
        private ProductRepository orderRepository;

        public ProductRepository Orders
        {
            get
            {
                if(orderRepository == null)
                {
                    orderRepository = new ProductRepository(db);
                }
                return orderRepository;

            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
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
        }
    }
}

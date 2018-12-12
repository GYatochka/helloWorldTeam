using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_WPF_
{
    class UnitOfWork : IDisposable
    {
        private ProductContext dbProducts = new ProductContext();
        private ProductRepository productRepository;
        private CheckRepository checkRepository;

        public ProductRepository Products
        {
            get
            {
                if(productRepository == null)
                {
                    productRepository = new ProductRepository(dbProducts);
                }
                return productRepository;

            }
        }
        public CheckRepository Checks
        {
            get
            {
                if (checkRepository == null)
                {
                    checkRepository = new CheckRepository(dbProducts);
                }
                return checkRepository;

            }
        }
        public void Save()
        {
            dbProducts.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbProducts.Dispose();
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

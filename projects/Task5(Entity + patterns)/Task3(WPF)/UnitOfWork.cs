using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_WPF_
{
    /// <summary>
    /// реалізація патерну Unit of work
    /// </summary>
  public  class UnitOfWork : IDisposable
    {
        /// <summary>
        /// ініціалізація контексту для зв'язку з бд
        /// </summary>
        private ProductContext dbProducts = new ProductContext();
        /// <summary>
        /// репозиторій продуктів
        /// </summary>
        private ProductRepository productRepository;
        /// <summary>
        /// репозиторій чеків
        /// </summary>
        private CheckRepository checkRepository;

        /// <summary>
        /// перевіряємо чи репозиторії існують
        /// </summary>
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
        /// <summary>
        /// збереження змін в БД
        /// </summary>
        public void Save()
        {
            dbProducts.SaveChanges();
        }
        /// <summary>
        /// перевантаження методів з інтерфейсу IDisposable 
        /// </summary>
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

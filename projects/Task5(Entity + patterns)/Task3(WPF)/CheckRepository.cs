using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Task3_WPF_
{
    public class CheckRepository : IRepository<Check>
    {
        private ProductContext db;

        public CheckRepository(ProductContext context)
        {
            this.db = context;
        }

        public IEnumerable<Check> GetAll()
        {
            return db.Checks;
        }

        public Check GetById(string sushi_name)
        {
            return db.Checks.Find(sushi_name);
        }

        public void Create(Check p)
        {
            db.Checks.Add(p);
        }

        public void Update(Check p)
        {
            db.Entry(p).State = EntityState.Modified;
        }

        public void DeleteById(string sushi_name)
        {
            Check p = db.Checks.Find(sushi_name);
            if (p != null)
                db.Checks.Remove(p);
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

using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T p)
        {
            Context c = new Context();
            c.Remove(p);
            c.SaveChanges();

        }

        public T GetById(int id)
        {
            Context c = new Context();
            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            Context c = new Context();
            return c.Set<T>().ToList();

        }

        public void Update(T p)
        {
            Context c = new Context();
            c.Update(p);
            c.SaveChanges();

        }

        public void Insert(T p)
        {
            Context c = new Context();
            c.Add(p);
            c.SaveChanges();
        }
    }
}

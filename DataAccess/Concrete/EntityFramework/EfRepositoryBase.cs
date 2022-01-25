using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRepositoryBase<T> : IEntityRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;

        public EfRepositoryBase()
        {
            _object = context.Set<T>();   
        }
        public void Add(T entity)
        {
            _object.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _object.Remove(entity);
            context.SaveChanges();
        }

        public List<T> Get(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public List<T> GetAll()
        {
            return _object.ToList();

        }

        public void Update(T entity)
        {
            context.SaveChanges();
        }
    }
}

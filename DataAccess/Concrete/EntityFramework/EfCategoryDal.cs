using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        Context context = new Context();
        DbSet<Category> _object;

        public void Add(Category category)
        {
            _object.Add(category);
            context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _object.Remove(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _object.ToList();
        }

        public void Update(Category category)
        {
            context.SaveChanges();
        }
    }
}

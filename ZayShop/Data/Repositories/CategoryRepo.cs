using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Utilities;

namespace ZayShop.Data.Repositories
{
    public class CategoryRepo : GenericRepository<Category>
    {
        public CategoryRepo() : base(new ZayContext())
        {
        }

        public override IEnumerable<Category> ReadMany(Expression<Func<Category, bool>> predicate = null)
        {
            var data = _set.Include(p => p.Products);
            return predicate != null ? data.Where(predicate) : data;
        }
    }
}
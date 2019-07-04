using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.RealEstate.WebUI.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        void Save(T entity);

        void Delete(Int64 key);
    }
}
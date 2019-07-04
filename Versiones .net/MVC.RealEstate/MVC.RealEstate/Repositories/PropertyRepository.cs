using MVC.RealEstate.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.RealEstate.WebUI.Repositories
{
    public class PropertyRepository : IRepository<Property>
    {
        public IQueryable<Property> 
            GetAll()
        {
            return Dummies.DummyManager.GetProperties();
        }

        public IQueryable<Property> FindBy(System.Linq.Expressions.Expression<Func<Property, bool>> predicate)
        {
           return  Dummies.DummyManager.GetProperties().Where(predicate);
        }

        public void Save(Property entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long key)
        {
            throw new NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Web.Data.İnterfaces
{
    public interface IRepository<T>where T : class,new()
    {
        void Create(T entity);
        void Remove(T entity);
        List<T> GetAll();
        T GetById(object id);
        void Update(T entity);
        IQueryable<T> GetQueryable();
    }
}

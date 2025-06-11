using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Generic.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
        IEnumerable<T> GetAll();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter = null);
        T FirstOrDefault(Expression<Func<T, bool>> filter = null);
        T LastOrDefault(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        IEnumerable<T> GetListEnumerable(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int iDisplayStart = 0, int iDisplayLength = 0, string sortProperty = "", string sortOrder = "");
        IList<T> GetList(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int iDisplayStart = 0, int iDisplayLength = 0, string sortProperty = "", string sortOrder = "");
        IEnumerable<T> GetIEnumerableRange(IEnumerable<T> entities, int IDisplayStart, int IDisplayLength);
        IEnumerable<T> Sort(IEnumerable<T> entities, string sortProperty, string sortOrder);
        List<T> Sort(List<T> entities, string sortProperty, string sortOrder);
        int GetCount(Expression<Func<T, bool>> filter = null, string searchText = null);
    }
}

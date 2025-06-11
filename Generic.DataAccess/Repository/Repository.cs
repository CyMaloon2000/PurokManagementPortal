using Generic.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Generic.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly GenericContext _context;
        internal DbSet<T> dbSet;
        public Repository(GenericContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();   
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //This line of code will be use to equevalent to INNER JOIN functionality in SQL Query
            foreach (var includedProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includedProp.Trim());
            }

            if (orderBy != null)
            {
                return query = orderBy(query);
            }
            else
            {
                try
                {
                    return query;
                }
                catch
                {
                    throw new ArgumentException("Please consider checking the parameters.");
                }
            }
        }

        public IList<T> GetList(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int iDisplayStart = 0, int iDisplayLength = 0, string sortProperty = "", string sortOrder = "")
        {
            IEnumerable<T> entities = null;

            entities = Get(filter: filter, orderBy: orderBy, includeProperties: includeProperties);
            entities = GetIEnumerableRange(entities, iDisplayStart, iDisplayLength);

            if (!string.IsNullOrEmpty(sortProperty) && !string.IsNullOrEmpty(sortOrder))
            {
                entities = Sort(entities, sortProperty, sortOrder);
            }
            return entities.ToList();
        }

        public IEnumerable<T> GetListEnumerable(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int iDisplayStart = 0, int iDisplayLength = 0, string sortProperty = "", string sortOrder = "")
        {
            IEnumerable<T> entities = null;

            entities = Get(filter: filter, orderBy: orderBy, includeProperties: includeProperties);
            entities = GetIEnumerableRange(entities, iDisplayStart, iDisplayLength);

            if (!string.IsNullOrEmpty(sortProperty) && !string.IsNullOrEmpty(sortOrder))
            {
                entities = Sort(entities, sortProperty, sortOrder);
            }
            return entities;
        }

        public IEnumerable<T> GetIEnumerableRange(IEnumerable<T> entities, int IDisplayStart, int IDisplayLength)
        {
            return IDisplayLength > 0 && entities != null? entities.Skip(IDisplayStart).Take(IDisplayLength) : entities;
        }

        public IEnumerable<T> Sort(IEnumerable<T> entities, string sortProperty, string sortOrder)
        {
            var propInfo = typeof(T).GetProperty(sortProperty);
            if (propInfo == null)
            {
                return entities;
            }

            Func<T, object> keySelector = x => propInfo.GetValue(x, null);

            return sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase)
                ? entities.OrderByDescending(keySelector)
                : entities.OrderBy(keySelector);
        }

        public List<T> Sort(List<T> entities, string sortProperty, string sortOrder)
        {
            var propInfo = typeof(T).GetProperty(sortProperty);
            if (propInfo == null)
            {
                return entities;
            }

            Func<T, object> keySelector = x => propInfo.GetValue(x, null);

            return sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase)
                ? entities.OrderByDescending(keySelector).ToList<T>()
                : entities.OrderBy(keySelector).ToList<T>();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T LastOrDefault(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            return query.LastOrDefault();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
        }

        public int GetCount(Expression<Func<T, bool>> filter = null, string searchText = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                return query.Where(filter).Count();
            }

            return query.Count();
        }
    }
}

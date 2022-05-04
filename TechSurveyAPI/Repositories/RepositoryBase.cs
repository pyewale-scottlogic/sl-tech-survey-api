using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechSurveyAPI.Models;

namespace TechSurveyAPI.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TechnologyStackContext TechnologyStackContext { get; set; }
        public RepositoryBase(TechnologyStackContext TechnologyStackContext)
        {
            this.TechnologyStackContext = TechnologyStackContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.TechnologyStackContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.TechnologyStackContext.Set<T>()
                .Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.TechnologyStackContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.TechnologyStackContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.TechnologyStackContext.Set<T>().Remove(entity);
        }
    }
}

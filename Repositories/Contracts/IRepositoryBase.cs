using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IRepositoryBase<T>
{
	IQueryable<T> GetAll(bool trackChanges, Expression<Func<T, bool>> expression = null);
	T Get(bool trackChanges, Expression<Func<T, bool>> expression);
	void Create(T entity);
	void Update(T entity);
	void Delete(T entity);
}

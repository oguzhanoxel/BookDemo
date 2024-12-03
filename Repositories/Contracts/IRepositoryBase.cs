using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IRepositoryBase<T>
{
	PagedList<T> FindAll(PageRequestParameters requestParameters, bool trackChanges);
	PagedList<T> FindByCondition(PageRequestParameters requestParameters, Expression<Func<T, bool>> expression, bool trackChanges);
	void Create(T entity);
	void Update(T entity);
	void Delete(T entity);
}

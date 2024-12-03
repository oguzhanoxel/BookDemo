using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IAsyncRepositoryBase<T>
{
	Task<PagedList<T>> FindAllAsync(PageRequestParameters requestParameters, bool trackChanges);
	Task<PagedList<T>> FindByConditionAsync(PageRequestParameters requestParameters, Expression<Func<T, bool>> expression, bool trackChanges);
	Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
}

using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IAsyncRepositoryBase<T>
{
	Task<PagedList<T>> GetAllAsync(BookParameters bookParameters,
		bool trackChanges, Expression<Func<T, bool>> expression = null);
	Task<T> GetAsync(bool trackChanges, Expression<Func<T, bool>> expression);
}

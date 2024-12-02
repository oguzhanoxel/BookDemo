using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IAsyncRepositoryBase<T>
{
	Task<List<T>> FindAllAsync(bool trackChanges);
	Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
	Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
}

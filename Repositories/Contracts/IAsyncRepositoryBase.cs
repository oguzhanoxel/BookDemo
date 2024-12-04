using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IAsyncRepositoryBase<T>
{
	Task<T> GetAsync(bool trackChanges, Expression<Func<T, bool>> expression);
}

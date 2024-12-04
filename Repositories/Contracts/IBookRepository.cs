using Entities.Models;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IBookRepository : IAsyncRepositoryBase<Book>, IRepositoryBase<Book>
{
	PagedList<Book> GetAll(BookParameters bookParameters, bool trackChanges, Expression<Func<Book, bool>> expression = null);
	Task<PagedList<Book>> GetAllAsync(BookParameters bookParameters, bool trackChanges, Expression<Func<Book, bool>> expression = null);
}

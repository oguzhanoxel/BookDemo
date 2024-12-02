using Entities.Models;

namespace Repositories.Contracts;

public interface IBookRepository : IAsyncRepositoryBase<Book>, IRepositoryBase<Book>
{

}

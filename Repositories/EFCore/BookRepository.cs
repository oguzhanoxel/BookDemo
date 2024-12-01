using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
	public BookRepository(AppDbContext context) : base(context)
	{

	}
}

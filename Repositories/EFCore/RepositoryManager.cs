using Repositories.Contracts;

namespace Repositories.EFCore;

public class RepositoryManager : IRepositoryManager
{
	private readonly AppDbContext _context;
	private readonly Lazy<IBookRepository> _bookRepository;

	public RepositoryManager(AppDbContext context)
	{
		_context = context;
		_bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
	}

	public IBookRepository Book => _bookRepository.Value;

	public void Save()
	{
		_context.SaveChanges();
	}
}

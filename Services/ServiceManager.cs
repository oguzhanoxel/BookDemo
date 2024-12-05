using AutoMapper;
using Entities.DTOs.Book;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
	private readonly Lazy<IBookService> _bookService;
	public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper, IDataShaper<BookResponseDto> shaper)
	{
		_bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, logger, mapper, shaper));
	}
	public IBookService BookService => _bookService.Value;
}
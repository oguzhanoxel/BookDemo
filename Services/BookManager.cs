using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class BookManager : IBookService
{
	private readonly IRepositoryManager _manager;
	private readonly ILoggerService _logger;

	public BookManager(IRepositoryManager manager, ILoggerService logger)
	{
		_manager = manager;
		_logger = logger;
	}

	public Book Create(Book book)
	{
		_manager.Book.Create(book);
		_manager.Save();
		return book;
	}

	public Book Delete(int id, bool trackChanges)
	{
		var entity = _manager.Book.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
		if (entity is null) throw new BookNotFoundException(id);
		
		_manager.Book.Delete(entity);
		_manager.Save();
		return entity;
	}

	public IEnumerable<Book> GetAll(bool trackChanges)
	{
		return _manager.Book.FindAll(trackChanges).ToList();
	}

	public Book GetById(int id, bool trackChanges)
	{
		var entity = _manager.Book.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
		if (entity is null) throw new BookNotFoundException(id);

		return entity;
	}

	public Book Update(int id, Book book, bool trackChanges)
	{
		var entity = _manager.Book.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
		if (entity is null) throw new BookNotFoundException(id);

		entity.Title = book.Title;
		entity.Price = book.Price;

		_manager.Book.Update(entity);
		_manager.Save();
		return entity;
	}
}

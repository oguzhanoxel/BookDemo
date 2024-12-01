using AutoMapper;
using Entities.DTOs.Book;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class BookManager : IBookService
{
	private readonly IRepositoryManager _manager;
	private readonly ILoggerService _logger;
	private readonly IMapper _mapper;

	public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
	{
		_manager = manager;
		_logger = logger;
		_mapper = mapper;
	}

	public Book Create(CreateBookRequestDto dto)
	{
		var mapped = _mapper.Map<Book>(dto);
		_manager.Book.Create(mapped);
		_manager.Save();
		return mapped;
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

	public Book Update(int id, UpdateBookRequestDto dto, bool trackChanges)
	{
		var entity = _manager.Book.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
		if (entity is null) throw new BookNotFoundException(id);

		_mapper.Map(dto, entity);
		_manager.Book.Update(entity);
		_manager.Save();
		return entity;
	}
}

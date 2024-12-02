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

	public BookResponseDto Create(CreateBookRequestDto dto)
	{
		var book = _mapper.Map<Book>(dto);
		_manager.Book.Create(book);
		_manager.Save();
		return _mapper.Map<BookResponseDto>(book);
	}

	public BookResponseDto Delete(int id, bool trackChanges)
	{
		var book = _manager.Book.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
		if (book is null) throw new BookNotFoundException(id);
		
		_manager.Book.Delete(book);
		_manager.Save();
		return _mapper.Map<BookResponseDto>(book);
	}

	public IEnumerable<BookResponseDto> GetAll(bool trackChanges)
	{
		var entities = _manager.Book.FindAll(trackChanges).ToList();
		return _mapper.Map<IEnumerable<BookResponseDto>>(entities);
	}

	public (UpdateBookRequestDto dto, Book book) GetBookForPatch(int id, bool trackChanges)
	{
		var book = _manager.Book.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
		if (book is null) throw new BookNotFoundException(id);

		var dto = _mapper.Map<UpdateBookRequestDto>(book);

		return (dto, book);
	}

	public BookResponseDto GetById(int id, bool trackChanges)
	{
		var book = _manager.Book.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
		if (book is null) throw new BookNotFoundException(id);
		return _mapper.Map<BookResponseDto>(book);
	}

	public void SaveForPatch(UpdateBookRequestDto dto, Book book)
	{
		_mapper.Map(dto, book);
		_manager.Save();
	}

	public BookResponseDto Update(int id, UpdateBookRequestDto dto, bool trackChanges)
	{
		var book = _manager.Book.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
		if (book is null) throw new BookNotFoundException(id);

		_mapper.Map(dto, book);
		_manager.Book.Update(book);
		_manager.Save();
		return _mapper.Map<BookResponseDto>(book);
	}
}

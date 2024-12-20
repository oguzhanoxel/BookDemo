﻿using AutoMapper;
using Entities.DTOs.Book;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services;

public class BookManager : IBookService
{
	private readonly IRepositoryManager _manager;
	private readonly ILoggerService _logger;
	private readonly IMapper _mapper;
	private readonly IDataShaper<BookResponseDto> _shaper;

	public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<BookResponseDto> shaper)
	{
		_manager = manager;
		_logger = logger;
		_mapper = mapper;
		_shaper = shaper;
	}

	public async Task<BookResponseDto> CreateAsync(CreateBookRequestDto dto)
	{
		var book = _mapper.Map<Book>(dto);
		_manager.Book.Create(book);
		await _manager.SaveAsync();
		return _mapper.Map<BookResponseDto>(book);
	}

	public async Task<BookResponseDto> DeleteAsync(int id, bool trackChanges)
	{
		Book? book = await GetBookIfIsExists(id, trackChanges);

		_manager.Book.Delete(book);
		await _manager.SaveAsync();
		return _mapper.Map<BookResponseDto>(book);
	}

	public async Task<(IEnumerable<ExpandoObject> books, MetaData metaData)> GetAllAsync(BookParameters bookParameters, bool trackChanges)
	{
		if (!bookParameters.ValidPriceRange) throw new PriceOutOfRangeBadRequestException();
		var pagedBookList = await _manager.Book.GetAllAsync(bookParameters, trackChanges);
		var books = _mapper.Map<IEnumerable<BookResponseDto>>(pagedBookList);
		var shapedBooks = _shaper.ShapeData(books, bookParameters.Fields);
		return (shapedBooks, pagedBookList.MetaData);
	}

	public async Task<(UpdateBookRequestDto dto, Book book)> GetBookForPatchAsync(int id, bool trackChanges)
	{
		Book? book = await GetBookIfIsExists(id, trackChanges);

		var dto = _mapper.Map<UpdateBookRequestDto>(book);

		return (dto, book);
	}

	public async Task<BookResponseDto> GetByIdAsync(int id, bool trackChanges)
	{
		Book? book = await GetBookIfIsExists(id, trackChanges);
		return _mapper.Map<BookResponseDto>(book);
	}

	public async Task SaveForPatchAsync(UpdateBookRequestDto dto, Book book)
	{
		_mapper.Map(dto, book);
		_manager.Book.Update(book);
		await _manager.SaveAsync();
	}

	public async Task<BookResponseDto> UpdateAsync(int id, UpdateBookRequestDto dto, bool trackChanges)
	{
		Book? book = await GetBookIfIsExists(id, trackChanges);

		_mapper.Map(dto, book);
		_manager.Book.Update(book);
		await _manager.SaveAsync();
		return _mapper.Map<BookResponseDto>(book);
	}

	private async Task<Book?> GetBookIfIsExists(int id, bool trackChanges)
	{
		var book = await _manager.Book.GetAsync(trackChanges, x => x.Id == id);
		if (book is null) throw new BookNotFoundException(id);
		return book;
	}
}

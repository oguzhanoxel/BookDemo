using Entities.DTOs.Book;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
	private readonly IServiceManager _manager;

	public BooksController(IServiceManager manager)
	{
		_manager = manager;
	}

	[HttpGet]
	public IActionResult GetAllBooks()
	{
		var books = _manager.BookService.GetAll(false);
		return Ok(books);
	}

	[HttpGet("{id:int}")]
	public IActionResult GetBookById(int id)
	{
		var book = _manager.BookService.GetById(id, false);
		return Ok(book);
	}

	[HttpPost]
	public IActionResult CreateBook([FromBody] CreateBookRequestDto dto)
	{
		if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
		_manager.BookService.Create(dto);
		return StatusCode(201, dto);
	}

	[HttpPut("{id:int}")]
	public IActionResult UpdateBook([FromRoute] int id, [FromBody] UpdateBookRequestDto dto)
	{
		if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
		var result = _manager.BookService.Update(id, dto, true);
		return Ok(result);
	}

	[HttpDelete("{id:int}")]
	public IActionResult DeleteBook([FromRoute] int id)
	{
		_manager.BookService.Delete(id, false);
		return NoContent();
	}

	[HttpPatch("{id:int}")]
	public IActionResult UpdateBookField([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateBookRequestDto> updated)
	{
		var book = _manager.BookService.GetBookForPatch(id, false);
		updated.ApplyTo(book.dto, ModelState);
		TryValidateModel(book.dto);
		if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

		_manager.BookService.SaveForPatch(book.dto, book.book);
		return NoContent();
	}
}


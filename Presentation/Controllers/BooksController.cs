using Entities;
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
		try
		{
			var books = _manager.BookService.GetAll(false);
			return Ok(books);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	[HttpGet("{id:int}")]
	public IActionResult GetBookById(int id)
	{
		try
		{
			var book = _manager.BookService.GetById(id, false);

			if (book is null) return NotFound();
			return Ok(book);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	[HttpPost]
	public IActionResult CreateBook([FromBody] CreateBookDto dto)
	{
		try
		{
			_manager.BookService.Create((Book)dto);
			return StatusCode(201, dto);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	[HttpPut("{id:int}")]
	public IActionResult UpdateBook([FromRoute] int id, [FromBody] UpdateBookDto dto)
	{
		try
		{
			var result = _manager.BookService.Update(id, (Book)dto, true);
			return Ok(result);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	[HttpDelete("{id:int}")]
	public IActionResult DeleteBook([FromRoute] int id)
	{
		try
		{
			_manager.BookService.Delete(id, false);
			return NoContent();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	[HttpPatch("{id:int}")]
	public IActionResult UpdateFieldBook([FromRoute] int id, [FromBody] JsonPatchDocument<Book> updated)
	{
		try
		{
			var book = _manager.BookService.GetById(id, true);

			if (book is null) return NotFound();

			updated.ApplyTo(book);
			_manager.BookService.Update(book.Id, book, true);
			return NoContent();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}


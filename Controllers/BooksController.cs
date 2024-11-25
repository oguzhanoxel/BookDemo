using BookDemo.Models;
using BookDemo.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
	private readonly AppDbContext _context;

	public BooksController(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public IActionResult GetAllBooks()
	{
		try
		{
			var books = _context.Books.ToList();
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
			var book = _context
				.Books
				.Where(b => b.Id.Equals(id))
				.SingleOrDefault();

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
			_context.Books.Add((Book)dto);
			_context.SaveChanges();
			return StatusCode(201, dto);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	[HttpPut("{id:int}")]
	public IActionResult UpdateBook([FromRoute]int id, [FromBody] UpdateBookDto dto)
	{
		try
		{
			var book = _context
				.Books
				.SingleOrDefault(b => b.Id.Equals(id));

			if (book is null) return NotFound();
			book.Title = dto.Title;
			book.Price = dto.Price;
			_context.Books.Update(book);
			_context.SaveChanges();
			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	[HttpDelete("{id:int}")]
	public IActionResult DeleteBook([FromRoute]int id)
	{
		try
		{
			var book = _context
				.Books
				.SingleOrDefault(b => b.Id.Equals(id));

			if (book is null) return NotFound(new
			{
				statusCode = 404,
				message = $"Book with id:{id} could not found."
			});

			_context.Books.Remove(book);
			_context.SaveChanges();
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
			var book = _context
				.Books
				.SingleOrDefault(b => b.Id.Equals(id));

			if (book is null) return NotFound();

			updated.ApplyTo(book);
			_context.Books.Update(book);
			_context.SaveChanges();
			return NoContent();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}

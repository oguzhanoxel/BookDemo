using BookDemo.Data;
using BookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
	[HttpGet]
	public IActionResult GetAllBooks()
	{
		var books = ApplicationContext.Books;
		return Ok(books);
	}

	[HttpGet("{id:int}")]
	public IActionResult GetBookById(int id)
	{
		var book = ApplicationContext
			.Books
			.Where(b => b.Id.Equals(id))
			.SingleOrDefault();

		if (book is null) return NotFound();
		return Ok(book);
	}

	[HttpPost]
	public IActionResult CreateBook([FromBody] Book book)
	{
		try
		{
			if (book is null) return BadRequest();

			ApplicationContext.Books.Add(book);
			return StatusCode(201, book);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut("{id:int}")]
	public IActionResult UpdateBook([FromRoute]int id, [FromBody] UpdateBookDto updated)
	{
		var book = ApplicationContext
			.Books
			.Find(b => b.Id.Equals(id));

		if (book is null) return NotFound();

		ApplicationContext.Books.Remove(book);
		var mapped = (Book)updated;
		mapped.Id = id;
		ApplicationContext.Books.Add((Book)mapped);
		return Ok(mapped);
	}

	[HttpDelete("{id:int}")]
	public IActionResult DeleteBook([FromRoute]int id)
	{
		var book = ApplicationContext
			.Books
			.Find(b => b.Id.Equals(id));

		if (book is null) return NotFound(new
		{
			statusCode = 404,
			message = $"Book with id:{id} could not found."
		});

		ApplicationContext.Books.Remove(book);
		return NoContent();
	}

	[HttpPatch("{id:int}")]
	public IActionResult UpdateFieldBook([FromRoute] int id, [FromBody] JsonPatchDocument<Book> updated)
	{
		var book = ApplicationContext
			.Books
			.Find(b => b.Id.Equals(id));

		if (book is null) return NotFound();

		updated.ApplyTo(book);
		return NoContent();
	}
}

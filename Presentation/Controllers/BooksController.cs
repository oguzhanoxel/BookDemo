using Entities.DTOs.Book;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ServiceFilter(typeof(LogFilterAttribute))]
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
	public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookParameters bookParameters)
	{
		var pagedBooks = await _manager.BookService
			.GetAllAsync(bookParameters, false);
		Response.Headers.Add("X-Pagination",
			JsonSerializer.Serialize(pagedBooks.metaData));
		return Ok(pagedBooks.books);
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetBookByIdAsync(int id)
	{
		var book = await _manager.BookService.GetByIdAsync(id, false);
		return Ok(book);
	}

	[ServiceFilter(typeof(ValidationFilterAttribute))]
	[HttpPost]
	public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookRequestDto dto)
	{
		await _manager.BookService.CreateAsync(dto);
		return StatusCode(201, dto);
	}

	[ServiceFilter(typeof(ValidationFilterAttribute))]
	[HttpPut("{id:int}")]
	public async Task<IActionResult> UpdateBookAsync([FromRoute] int id, [FromBody] UpdateBookRequestDto dto)
	{
		var result = await _manager.BookService.UpdateAsync(id, dto, true);
		return Ok(result);
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
	{
		await _manager.BookService.DeleteAsync(id, false);
		return NoContent();
	}

	[HttpPatch("{id:int}")]
	public async Task<IActionResult> UpdateBookFieldAsync([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateBookRequestDto> updated)
	{
		var book = await _manager.BookService.GetBookForPatchAsync(id, false);
		updated.ApplyTo(book.dto, ModelState);
		TryValidateModel(book.dto);
		if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

		await _manager.BookService.SaveForPatchAsync(book.dto, book.book);
		return NoContent();
	}
}


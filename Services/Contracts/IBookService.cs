using Entities.DTOs.Book;
using Entities.Models;

namespace Services.Contracts;

public interface IBookService
{
	IEnumerable<Book> GetAll(bool trackChanges);
	Book GetById(int id, bool trackChanges);
	Book Create(CreateBookRequestDto dto);
	Book Update(int id, UpdateBookRequestDto dto, bool trackChanges);
	Book Delete(int id, bool trackChanges);
}

using Entities.Models;

namespace Services.Contracts;

public interface IBookService
{
	IEnumerable<Book> GetAll(bool trackChanges);
	Book GetById(int id, bool trackChanges);
	Book Create(Book book);
	Book Update(int id, Book book, bool trackChanges);
	Book Delete(int id, bool trackChanges);
}

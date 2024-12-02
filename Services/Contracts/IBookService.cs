using Entities.DTOs.Book;
using Entities.Models;

namespace Services.Contracts;

public interface IBookService
{
	IEnumerable<BookResponseDto> GetAll(bool trackChanges);
	BookResponseDto GetById(int id, bool trackChanges);
	BookResponseDto Create(CreateBookRequestDto dto);
	BookResponseDto Update(int id, UpdateBookRequestDto dto, bool trackChanges);
	BookResponseDto Delete(int id, bool trackChanges);
	(UpdateBookRequestDto dto, Book book) GetBookForPatch(int id, bool trackChanges);
	void SaveForPatch(UpdateBookRequestDto dto, Book book);
}

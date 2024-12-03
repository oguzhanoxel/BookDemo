using Entities.DTOs.Book;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface IBookService
{
	Task<(IEnumerable<BookResponseDto> books, MetaData metaData)> GetAllAsync(PageRequestParameters requestParameters, bool trackChanges);
	Task<BookResponseDto> GetByIdAsync(int id, bool trackChanges);
	Task<BookResponseDto> CreateAsync(CreateBookRequestDto dto);
	Task<BookResponseDto> UpdateAsync(int id, UpdateBookRequestDto dto, bool trackChanges);
	Task<BookResponseDto> DeleteAsync(int id, bool trackChanges);
	Task<(UpdateBookRequestDto dto, Book book)> GetBookForPatchAsync(int id, bool trackChanges);
	Task SaveForPatchAsync(UpdateBookRequestDto dto, Book book);
}

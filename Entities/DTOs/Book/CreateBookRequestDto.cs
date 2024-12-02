using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Book;

public class CreateBookRequestDto
{
	[Required]
	[MinLength(2)]
	[MaxLength(50)]
	public string Title { get; set; }
	[Required]
	[Range(0, 100000000)]
	public decimal Price { get; set; }
}
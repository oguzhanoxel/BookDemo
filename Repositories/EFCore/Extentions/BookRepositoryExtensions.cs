﻿using Entities.Models;

namespace Repositories.EFCore.Extentions;

public static class BookRepositoryExtensions
{
	public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, uint minPrice, uint maxPrice) =>
		books.Where(book =>
		book.Price >= minPrice &&
		book.Price <= maxPrice);

	public static IQueryable<Book> Search(this IQueryable<Book> books, string searchTerm)
	{
		if(string.IsNullOrWhiteSpace(searchTerm)) return books;

		var lowerCaseTerm = searchTerm.Trim().ToLower();
		return books.Where(x => x.Title.ToLower().Contains(searchTerm));
	}
}

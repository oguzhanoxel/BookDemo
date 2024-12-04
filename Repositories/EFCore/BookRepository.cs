using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.EFCore;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
	public BookRepository(AppDbContext context) : base(context)
	{
		
	}

	public PagedList<Book> GetAll(BookParameters bookParameters, bool trackChanges, Expression<Func<Book, bool>> expression = null)
	{
		IQueryable<Book> query = GetAll(trackChanges, expression)
			.FilterBooks(bookParameters.MinPrice, bookParameters.MaxPrice);
		return PagedList<Book>.ToPagedList(query, bookParameters.PageNumber, bookParameters.PageSize);
	}

	public async Task<PagedList<Book>> GetAllAsync(BookParameters bookParameters, bool trackChanges, Expression<Func<Book, bool>> expression = null)
	{
		IQueryable<Book> query = GetAll(trackChanges, expression)
			.FilterBooks(bookParameters.MinPrice, bookParameters.MaxPrice);
		return await PagedList<Book>
			.ToPagedListAsync(query, bookParameters.PageNumber, bookParameters.PageSize);
	}
}
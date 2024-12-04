using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.EFCore;

public abstract class RepositoryBase<T> : IAsyncRepositoryBase<T>, IRepositoryBase<T>
	where T : class
{
	protected readonly AppDbContext _context;

	public RepositoryBase(AppDbContext context)
	{
		_context = context;
	}

	public void Create(T entity) => _context.Set<T>().Add(entity);
	public void Update(T entity) => _context.Set<T>().Update(entity);
	public void Delete(T entity) => _context.Set<T>().Remove(entity);
	public T Get(bool trackChanges, Expression<Func<T, bool>> expression)
	{
		IQueryable<T> query = _context.Set<T>();
		if (!trackChanges) query = query.AsNoTracking();

		return query.SingleOrDefault(expression);
	}
	public Task<T> GetAsync(bool trackChanges, Expression<Func<T, bool>> expression)
	{
		IQueryable<T> query = _context.Set<T>();
		if (!trackChanges) query = query.AsNoTracking();

		return query.SingleOrDefaultAsync(expression);
	}
	public PagedList<T> GetAll(BookParameters bookParameters,
		bool trackChanges, Expression<Func<T, bool>> expression = null)
	{
		IQueryable<T> query = _context.Set<T>();
		if (!trackChanges) query = query.AsNoTracking();
		if (expression is not null) query = query.Where(expression);

		return PagedList<T>.ToPagedList(query, bookParameters.PageNumber, bookParameters.PageSize);
	}
	public async Task<PagedList<T>> GetAllAsync(BookParameters bookParameters,
		bool trackChanges, Expression<Func<T, bool>> expression = null)
	{
		IQueryable<T> query = _context.Set<T>();
		if (!trackChanges) query = query.AsNoTracking();
		if (expression is not null) query = query.Where(expression);

		return await PagedList<T>.ToPagedListAsync(query, bookParameters.PageNumber, bookParameters.PageSize);
	}
}

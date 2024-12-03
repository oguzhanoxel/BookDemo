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

	public void Delete(T entity) => _context.Set<T>().Remove(entity);

	public PagedList<T> FindAll(PageRequestParameters requestParameters, bool trackChanges)
	{
		IQueryable<T> query = _context.Set<T>();
		if (!trackChanges)
			query = query.AsNoTracking();

		return PagedList<T>.ToPagedList(query, requestParameters.PageNumber, requestParameters.PageSize);
	}

	public async Task<PagedList<T>> FindAllAsync(PageRequestParameters requestParameters, bool trackChanges)
	{
		IQueryable<T> query = _context.Set<T>();
		if (!trackChanges)
			query = query.AsNoTracking();

		return await PagedList<T>.ToPagedListAsync(query, requestParameters.PageNumber, requestParameters.PageSize);
	}

	public PagedList<T> FindByCondition(PageRequestParameters requestParameters, Expression<Func<T, bool>> expression, bool trackChanges)
	{
		IQueryable<T> query = _context.Set<T>();
		if (!trackChanges)
			query = query.Where(expression).AsNoTracking();

		return PagedList<T>.ToPagedList(query.Where(expression), requestParameters.PageNumber, requestParameters.PageSize);
	}

	public async Task<PagedList<T>> FindByConditionAsync(PageRequestParameters requestParameters, Expression<Func<T, bool>> expression, bool trackChanges)
	{
		IQueryable<T> query = _context.Set<T>();
		if (!trackChanges)
			query = query.Where(expression).AsNoTracking();

		return await PagedList<T>.ToPagedListAsync(query.Where(expression), requestParameters.PageNumber, requestParameters.PageSize);
	}

	public async Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
	{
		return await (!trackChanges ?
		_context.Set<T>().Where(expression).AsNoTracking().SingleOrDefaultAsync() :
		_context.Set<T>().Where(expression).SingleOrDefaultAsync());
	}

	public void Update(T entity) => _context.Set<T>().Update(entity);
}

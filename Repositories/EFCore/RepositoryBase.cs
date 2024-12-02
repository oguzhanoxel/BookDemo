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

	public IQueryable<T> FindAll(bool trackChanges) =>
		!trackChanges ?
		_context.Set<T>().AsNoTracking() :
		_context.Set<T>();

	public async Task<List<T>> FindAllAsync(bool trackChanges)
	{
		return await (!trackChanges?
		_context.Set<T>().AsNoTracking().ToListAsync() :
		_context.Set<T>().ToListAsync());
	}
		

	public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
		!trackChanges ?
		_context.Set<T>().Where(expression).AsNoTracking() :
		_context.Set<T>().Where(expression);

	public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
	{
		return await(!trackChanges ?
		_context.Set<T>().Where(expression).AsNoTracking().ToListAsync() :
		_context.Set<T>().Where(expression).ToListAsync());
	}

	public async Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
	{
		return await (!trackChanges ?
		_context.Set<T>().Where(expression).AsNoTracking().SingleOrDefaultAsync() :
		_context.Set<T>().Where(expression).SingleOrDefaultAsync());
	}

	public void Update(T entity) => _context.Set<T>().Update(entity);
}

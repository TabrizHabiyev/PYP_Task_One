using Microsoft.EntityFrameworkCore;
using PYP_Task_One.Aplication.Repositories;
using PYP_Task_One.Domain.Common;
using PYP_Task_One.Persistence.Contexts;
using System.Linq.Expressions;

namespace PYP_Task_One.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly PYP_Task_OneDBContext _context;
    public ReadRepository(PYP_Task_OneDBContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll()
    {
        try
        {
            var query = Table.AsQueryable();
            return query;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
    {
        var query = Table.Where(method);
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
    {
        var query = Table.AsQueryable();
        return await query.FirstOrDefaultAsync(method);
    }


    public async Task<T> GetByIdAsync(string id)
    {
        var query = Table.AsQueryable();
        return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }
}

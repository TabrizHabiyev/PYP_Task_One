using Microsoft.EntityFrameworkCore;
using PYP_Task_One.Domain.Common;
using PYP_Task_One.Domain.Entites;

namespace PYP_Task_One.Persistence.Contexts;

public class PYP_Task_OneDBContext : DbContext
{
    public PYP_Task_OneDBContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Spreadsheet> Spreadsheets { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var item in datas)
        {
            _ = item.State switch
            {
                EntityState.Added => item.Entity.CreateDate = DateTime.Now,
                EntityState.Modified => item.Entity.UpdateDate = DateTime.Now
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

}


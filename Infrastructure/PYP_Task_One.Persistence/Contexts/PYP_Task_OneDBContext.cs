using Microsoft.EntityFrameworkCore;
using PYP_Task_One.Domain.Entites;

namespace PYP_Task_One.Persistence.Contexts;

public class PYP_Task_OneDBContext : DbContext
{
    public PYP_Task_OneDBContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Spreadsheet> Spreadsheets { get; set; }
    
}


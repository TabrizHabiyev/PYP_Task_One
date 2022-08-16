using Microsoft.EntityFrameworkCore;

namespace PYP_Task_One.Persistence.Contexts;

public class PYP_Task_OneDBContext : DbContext
{
    public PYP_Task_OneDBContext(DbContextOptions options) : base(options)
    {

    }
}


using Microsoft.EntityFrameworkCore;
using PYP_Task_One.Domain.Common;

namespace PYP_Task_One.Aplication.Repositories;

    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }


using PYP_Task_One.Domain.Common;

namespace PYP_Task_One.Aplication.Repositories;

    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);

        Task<bool> AddRangeAsync(List<T> datas);

        bool Remove(T model);

        Task<bool> RemoveAsync(string id);

        bool RemoveRange(List<T> datas);

        bool Update(T model);

        Task<int> SaveAsync();
    }


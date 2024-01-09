
using IdendtityCore.CoreEntities;
using IdendtityCore.Repositories.Abstractions;

namespace IdendtityCore.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class,IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}

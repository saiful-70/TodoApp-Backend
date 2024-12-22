using System.Data.Common;

namespace TodoApp;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    void Save();
    Task SaveAsync();
    Task<DbTransaction> BeginTransactionAsync(CancellationToken ct = default);
}

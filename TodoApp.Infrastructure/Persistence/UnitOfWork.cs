using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace TodoApp.Infrastructure.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly DbContext _dbContext;

    protected UnitOfWork(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual void Dispose()
    {
        _dbContext.Dispose();
    }

    public virtual ValueTask DisposeAsync()
    {
        return _dbContext.DisposeAsync();
    }

    public virtual void Save()
    {
        _dbContext.SaveChanges();
    }

    public virtual async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<DbTransaction> BeginTransactionAsync(CancellationToken ct = default)
    {
        var trx = await _dbContext.Database.BeginTransactionAsync(ct).ConfigureAwait(false);
        return trx.GetDbTransaction();
    }

}
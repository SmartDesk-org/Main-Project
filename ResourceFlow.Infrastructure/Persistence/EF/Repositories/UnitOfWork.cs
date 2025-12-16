using Microsoft.EntityFrameworkCore.Storage;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Infrastructure.Persistence.EF.Context;

public class UnitOfWork : IUnitOfWork
{
    public AppDbContext Db { get; }

    private IDbContextTransaction? _transaction;

    public UnitOfWork(AppDbContext db)
    {
        Db = db;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await Db.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await Db.SaveChangesAsync();
        await _transaction!.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction!.RollbackAsync();
    }

    public async Task SaveChangesAsync()
    {
        await Db.SaveChangesAsync();
    }
}

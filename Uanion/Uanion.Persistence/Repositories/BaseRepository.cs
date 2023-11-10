﻿using Microsoft.EntityFrameworkCore;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Persistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly UanionDbContext _dbContext;

    public BaseRepository(UanionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id) =>
        await _dbContext.Set<T>().FindAsync(id);

    public async Task<IReadOnlyList<T>> ListAllAsync() =>
        await _dbContext.Set<T>().ToListAsync();

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}

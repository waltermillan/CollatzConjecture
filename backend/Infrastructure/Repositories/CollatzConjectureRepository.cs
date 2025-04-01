using Core.Entities;
using Core.Interfases;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class CollatzConjectureRepository : ICollatzConjectureRepository
{
    private readonly IMongoCollection<CollatzConjecture> _collatzConjecture;

    public CollatzConjectureRepository(IMongoCollection<CollatzConjecture> collatzsConjecture)
    {
        _collatzConjecture = collatzsConjecture;
    }

    public async Task<IEnumerable<CollatzConjecture>> GetAllAsync()
    {
        var collatzsConjecture = await _collatzConjecture.Find(collatzConjecture => true).ToListAsync();
        return collatzsConjecture;
    }

    public async Task<CollatzConjecture> GetByIdAsync(ObjectId id)
    {
        var collatzConjecture = await _collatzConjecture.Find(collatzConjecture => collatzConjecture.Id == id).FirstOrDefaultAsync();
        return collatzConjecture;
    }

    public async void Add(CollatzConjecture collatzConjecture)
    {
        await _collatzConjecture.InsertOneAsync(collatzConjecture);
    }

    public async void AddRange(IEnumerable<CollatzConjecture> entities)
    {
        await _collatzConjecture.InsertManyAsync(entities);
    }

    public async void Remove(CollatzConjecture entity)
    {
        await _collatzConjecture.DeleteOneAsync(p => p.Id == entity.Id);
    }

    public async void RemoveRange(IEnumerable<CollatzConjecture> entities)
    {
        var ids = entities.Select(e => e.Id).ToList();
        await _collatzConjecture.DeleteManyAsync(p => ids.Contains(p.Id));
    }

    public async void Update(CollatzConjecture collatzConjecture)
    {
        await _collatzConjecture.ReplaceOneAsync(p => p.Id == collatzConjecture.Id, collatzConjecture);
    }

    public async Task<IEnumerable<CollatzConjecture>> Find(Expression<Func<CollatzConjecture, bool>> predicate)
    {
        return await _collatzConjecture.Find(predicate).ToListAsync();
    }

    public async Task CreateAsync(CollatzConjecture collatzConjecture)
    {
        await _collatzConjecture.InsertOneAsync(collatzConjecture);
    }

    public async Task UpdateAsync(CollatzConjecture collatzConjecture)
    {
        await _collatzConjecture.ReplaceOneAsync(p => p.Id == collatzConjecture.Id, collatzConjecture);
    }

    public async Task DeleteAsync(ObjectId id)
    {
        await _collatzConjecture.DeleteOneAsync(p => p.Id == id);
    }
}

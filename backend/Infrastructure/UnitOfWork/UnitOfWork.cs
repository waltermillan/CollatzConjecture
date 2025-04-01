using Core.Interfases;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly IMongoDatabase _database;
    private ICollatzConjectureRepository _collatzConjecture;

    public UnitOfWork(IMongoClient mongoClient, IConfiguration configuration)
    {
        var databaseName = configuration["ProductDBName"]; // Read database name from configuration
        _database = mongoClient.GetDatabase(databaseName);
    }

    public ICollatzConjectureRepository CollatzsConjecture
    {
        get
        {
            if (_collatzConjecture is null)
                // Passing the MongoDB collection to the repository
                _collatzConjecture = new CollatzConjectureRepository(_database.GetCollection<Core.Entities.CollatzConjecture>("CollatzConjecture"));

            return _collatzConjecture;
        }
    }

    public void Dispose()
    {

    }

    public Task<int> SaveAsync()
    {
        return Task.FromResult(1);
    }
}

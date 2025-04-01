using Core.Interfases;

namespace Core.Interfases;

public interface IUnitOfWork
{
    ICollatzConjectureRepository CollatzsConjecture { get; }
    void Dispose();
    Task<int> SaveAsync();
}

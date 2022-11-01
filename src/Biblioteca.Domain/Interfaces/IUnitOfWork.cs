namespace Biblioteca.Domain.Interfaces;

public interface IUnitOfWork: IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}
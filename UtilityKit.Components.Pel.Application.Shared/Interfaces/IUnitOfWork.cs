namespace UtilityKit.Components.Pel.Application.Shared.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}

using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IMiniatureCollectionRepository: IRepository<MiniatureCollection>
{
    Task<IEnumerable<MiniatureCollection>> AllAsync(Guid userId);
    Task<MiniatureCollection?> FindAsync(Guid id, Guid userId);
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
    Task RemoveAsync(Guid id, Guid userId);
}
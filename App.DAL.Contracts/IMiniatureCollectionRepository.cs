using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IMiniatureCollectionRepository: IRepository<MiniatureCollection>
{
    Task<IEnumerable<MiniatureCollection>> AllWithIncludesAsync(Guid userId);
    Task<MiniatureCollection?> FindWithIncludesAsync(Guid id, Guid userId);
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
}
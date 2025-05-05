using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IMiniatureCollectionRepository: IBaseRepository<App.DAL.DTO.MiniatureCollection>
{
    Task<IEnumerable<App.DAL.DTO.MiniatureCollection>> AllAsync(Guid userId);
    Task<App.DAL.DTO.MiniatureCollection?> FindAsync(Guid id, Guid userId);
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
    Task RemoveAsync(Guid id, Guid userId);
}
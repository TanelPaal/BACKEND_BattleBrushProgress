using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IMiniPaintSwatchRepository: IBaseRepository<App.DAL.DTO.MiniPaintSwatch>
{
    Task<IEnumerable<App.DAL.DTO.MiniPaintSwatch>> AllAsync(Guid userId);
    Task<App.DAL.DTO.MiniPaintSwatch?> FindAsync(Guid id, Guid userId);
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
    Task RemoveAsync(Guid id, Guid userId);
}
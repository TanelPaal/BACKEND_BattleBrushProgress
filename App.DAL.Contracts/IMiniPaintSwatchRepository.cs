using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IMiniPaintSwatchRepository: IBaseRepository<MiniPaintSwatch>
{
    Task<IEnumerable<MiniPaintSwatch>> AllAsync(Guid userId);
    Task<MiniPaintSwatch?> FindAsync(Guid id, Guid userId);
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
    Task RemoveAsync(Guid id, Guid userId);
}
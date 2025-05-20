using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IMiniPaintSwatchRepository : IBaseRepository<App.DAL.DTO.MiniPaintSwatch>
{
    Task<IEnumerable<App.DAL.DTO.MiniPaintSwatch>> AllAsync(Guid userId);
}
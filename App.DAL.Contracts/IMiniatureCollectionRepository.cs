using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IMiniatureCollectionRepository: IBaseRepository<App.DAL.DTO.MiniatureCollection>
{
    Task<List<MiniatureCollection>> GetAllByUserIdAsync(Guid userId);
    Task<List<App.DAL.DTO.MiniatureCollection>> AllWithPaintSwatchesAsync(Guid userId);
}
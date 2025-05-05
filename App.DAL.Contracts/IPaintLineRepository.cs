using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IPaintLineRepository: IBaseRepository<App.DAL.DTO.PaintLine>
{
    Task<IEnumerable<App.DAL.DTO.PaintLine>> AllWithIncludesAsync();
    Task<App.DAL.DTO.PaintLine> FindWithIncludesAsync(Guid id);
}
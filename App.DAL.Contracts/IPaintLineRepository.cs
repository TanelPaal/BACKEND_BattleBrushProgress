using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IPaintLineRepository: IRepository<PaintLine>
{
    Task<IEnumerable<PaintLine>> AllWithIncludesAsync();
    Task<PaintLine> FindWithIncludesAsync(Guid id);
}
using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IPaintRepository: IBaseRepository<App.DAL.DTO.Paint>
{
    Task<IEnumerable<App.DAL.DTO.Paint>> AllWithIncludesAsync();
    Task<App.DAL.DTO.Paint?> FindWithIncludesAsync(Guid id);
}
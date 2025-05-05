using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IMiniatureRepository: IBaseRepository<App.DAL.DTO.Miniature>
{
    Task<IEnumerable<App.DAL.DTO.Miniature>> AllWithIncludesAsync();
    Task<App.DAL.DTO.Miniature?> FindWithIncludesAsync(Guid id);
}
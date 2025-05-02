using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IMiniatureRepository: IRepository<Miniature>
{
    Task<IEnumerable<Miniature>> AllWithIncludesAsync();
    Task<Miniature?> FindWithIncludesAsync(Guid id);
}
using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IPaintRepository: IRepository<Paint>
{
    Task<IEnumerable<Paint>> AllWithIncludesAsync();
    Task<Paint?> FindWithIncludesAsync(Guid id);
}
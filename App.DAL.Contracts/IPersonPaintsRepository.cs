using App.Domain;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IPersonPaintsRepository: IBaseRepository<PersonPaints>
{
    Task<IEnumerable<PersonPaints>> AllAsync(Guid userId);
    Task<PersonPaints?> FindAsync(Guid id, Guid userId);
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
    Task RemoveAsync(Guid id, Guid userId);
}
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IPersonPaintsRepository: IBaseRepository<App.DAL.DTO.PersonPaints>
{
    Task<IEnumerable<DTO.PersonPaints>> AllAsync(Guid userId);
    Task<DTO.PersonPaints?> FindAsync(Guid id, Guid userId);
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
    Task RemoveAsync(Guid id, Guid userId);
}
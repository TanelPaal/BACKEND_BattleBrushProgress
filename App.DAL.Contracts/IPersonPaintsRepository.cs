using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IPersonPaintsRepository : IBaseRepository<App.DAL.DTO.PersonPaints>
{
    Task<List<App.DAL.DTO.PersonPaints>> AllWithPaintDetailsAsync(Guid userId);
}

using App.DTO.v1;

namespace App.BLL.Contracts;

public interface IPersonPaintsStatsService
{
    Task<PersonPaintsStats> GetUserPaintsStats(Guid userId);
}
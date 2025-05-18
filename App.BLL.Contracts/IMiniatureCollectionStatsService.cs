using App.DTO.v1;

namespace App.BLL.Contracts;

public interface IMiniatureCollectionStatsService
{
    Task<MiniatureCollectionStats> GetUserCollectionStats(Guid userId);
}
using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DTO.v1;

namespace App.BLL.Services;

public class MiniatureCollectionStatsService : IMiniatureCollectionStatsService
{
    private readonly IMiniatureCollectionRepository _miniatureCollectionRepository;
    private readonly IMiniStateRepository _miniStateRepository;

    public MiniatureCollectionStatsService(
        IMiniatureCollectionRepository miniatureCollectionRepository,
        IMiniStateRepository miniStateRepository)
    {
        _miniatureCollectionRepository = miniatureCollectionRepository;
        _miniStateRepository = miniStateRepository;
    }

    public async Task<MiniatureCollectionStats> GetUserCollectionStats(Guid userId)
    {
        var stats = new MiniatureCollectionStats();
        
        // Get all miniatures for the user
        var userMiniatures = await _miniatureCollectionRepository.GetAllByUserIdAsync(userId);
        
        // Get all possible states
        var states = await _miniStateRepository.AllAsync();
        
        // Initialize state counts
        foreach (var state in states)
        {
            stats.MiniaturesByState[state.StateName] = 0;
        }
        
        // Count miniatures by state and month
        foreach (var miniature in userMiniatures)
        {
            // Count by state
            if (miniature.MiniState != null)
            {
                stats.MiniaturesByState[miniature.MiniState.StateName]++;
            }
            
            // Count by month (using acquisition date)
            var monthKey = miniature.AcquisitionDate.ToString("yyyy-MM");
            if (!stats.MiniaturesByMonth.ContainsKey(monthKey))
            {
                stats.MiniaturesByMonth[monthKey] = 0;
            }
            stats.MiniaturesByMonth[monthKey]++;
        }
        
        stats.TotalMiniatures = userMiniatures.Count;
        
        return stats;
    }
}
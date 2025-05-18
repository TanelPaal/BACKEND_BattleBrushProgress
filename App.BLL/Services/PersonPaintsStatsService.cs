using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DTO.v1;

namespace App.BLL.Services;

public class PersonPaintsStatsService : IPersonPaintsStatsService
{
    private readonly IAppUOW _uow;

    public PersonPaintsStatsService(IAppUOW uow)
    {
        _uow = uow;
    }

    public async Task<PersonPaintsStats> GetUserPaintsStats(Guid userId)
    {
        var stats = new PersonPaintsStats();
        
        // Use the new method!
        var userPaints = await _uow.PersonPaintsRepository.AllWithPaintDetailsAsync(userId);
        
        // Initialize counters
        foreach (var paint in userPaints)
        {
            if (paint.Paint?.Brand != null)
            {
                var brandName = paint.Paint.Brand.BrandName;
                if (!stats.PaintsByBrand.ContainsKey(brandName))
                {
                    stats.PaintsByBrand[brandName] = 0;
                }
                stats.PaintsByBrand[brandName] += paint.Quantity;
            }

            if (paint.Paint?.PaintType != null)
            {
                var typeName = paint.Paint.PaintType.Name;
                if (!stats.PaintsByType.ContainsKey(typeName))
                {
                    stats.PaintsByType[typeName] = 0;
                }
                stats.PaintsByType[typeName] += paint.Quantity;
            }

            // Count by month
            var monthKey = paint.AcquisitionDate.ToString("yyyy-MM");
            if (!stats.PaintsByMonth.ContainsKey(monthKey))
            {
                stats.PaintsByMonth[monthKey] = 0;
            }
            stats.PaintsByMonth[monthKey] += paint.Quantity;
        }
        
        stats.TotalPaints = userPaints.Sum(p => p.Quantity);
        
        return stats;
    }
}
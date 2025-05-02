using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PaintRepository : BaseRepository<Paint>, IPaintRepository
{
    public PaintRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Paint>> AllWithIncludesAsync()
    {
        return await RepositoryDbSet
            .Include(p => p.Brand)
            .Include(p => p.PaintLine)
            .Include(p => p.PaintType)
            .ToListAsync();
    }

    public async Task<Paint?> FindWithIncludesAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(p => p.Brand)
            .Include(p => p.PaintLine)
            .Include(p => p.PaintType)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
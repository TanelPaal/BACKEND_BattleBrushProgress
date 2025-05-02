using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class MiniatureRepository : BaseRepository<Miniature>, IMiniatureRepository
{
    public MiniatureRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
    public async Task<IEnumerable<Miniature>> AllWithIncludesAsync()
    {
        return await RepositoryDbSet
            .Include(m => m.MiniFaction)
            .Include(m => m.MiniManufacturer)
            .Include(m => m.MiniProperties)
            .ToListAsync();
    }

    public async Task<Miniature?> FindWithIncludesAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(m => m.MiniFaction)
            .Include(m => m.MiniManufacturer)
            .Include(m => m.MiniProperties)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}
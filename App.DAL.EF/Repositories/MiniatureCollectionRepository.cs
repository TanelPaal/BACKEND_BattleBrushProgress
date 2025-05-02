using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class MiniatureCollectionRepository : BaseRepository<MiniatureCollection>, IMiniatureCollectionRepository
{
    public MiniatureCollectionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
    public async Task<IEnumerable<MiniatureCollection>> AllWithIncludesAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(m => m.User)
            .Include(m => m.Miniature)
            .Include(m => m.MiniState)
            .Include(m => m.Person)
            .Where(m => m.UserId == userId)
            .ToListAsync();
    }

    public async Task<MiniatureCollection?> FindWithIncludesAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(m => m.User)
            .Include(m => m.Miniature)
            .Include(m => m.MiniState)
            .Include(m => m.Person)
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .AnyAsync(m => m.Id == id && m.UserId == userId);
    }
}
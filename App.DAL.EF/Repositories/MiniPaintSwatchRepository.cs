using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class MiniPaintSwatchRepository : BaseRepository<MiniPaintSwatch>, IMiniPaintSwatchRepository
{
    public MiniPaintSwatchRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
    public override async Task<IEnumerable<MiniPaintSwatch>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(m => m.MiniatureCollection)
            .Include(m => m.PersonPaints)
            .Where(m => m.UserId == userId)
            .ToListAsync();
    }

    public override async Task<MiniPaintSwatch?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(m => m.MiniatureCollection)
            .Include(m => m.PersonPaints)
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .AnyAsync(m => m.Id == id && m.UserId == userId);
    }

    public async Task RemoveAsync(Guid id, Guid userId)
    {
        var entity = await RepositoryDbSet
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            
        if (entity != null)
        {
            RepositoryDbSet.Remove(entity);
        }
    }
}
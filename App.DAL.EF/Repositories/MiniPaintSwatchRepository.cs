using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class MiniPaintSwatchRepository : BaseRepository<App.DAL.DTO.MiniPaintSwatch, App.Domain.MiniPaintSwatch>, IMiniPaintSwatchRepository
{
    public MiniPaintSwatchRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniPaintSwatchMapper())
    {
    }
    
    public override async Task<IEnumerable<App.DAL.DTO.MiniPaintSwatch>> AllAsync(Guid userId)
    {
        return (await RepositoryDbSet
            .Include(m => m.MiniatureCollection)
            .Include(m => m.PersonPaints)
            .Where(m => m.UserId == userId)
            .ToListAsync()).Select(e => Mapper.Map(e)!);;
    }

    public override async Task<App.DAL.DTO.MiniPaintSwatch?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(m => m.MiniatureCollection)
            .Include(m => m.PersonPaints)
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId));
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
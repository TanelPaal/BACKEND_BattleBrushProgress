using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class MiniatureCollectionRepository : BaseRepository<App.DAL.DTO.MiniatureCollection, App.Domain.MiniatureCollection>, IMiniatureCollectionRepository
{
    public MiniatureCollectionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniatureCollectionMapper())
    {
    }
    
    public override async Task<IEnumerable<App.DAL.DTO.MiniatureCollection>> AllAsync(Guid userId = default!)
    {
        return (await RepositoryDbSet
            .Include(m => m.Miniature)
            .Include(m => m.MiniState)
            .Include(m => m.Person)
            .Where(m => m.UserId == userId)
            .ToListAsync()).Select(e => Mapper.Map(e)!);
    }

    public override async Task<App.DAL.DTO.MiniatureCollection?> FindAsync(Guid id, Guid userId = default!)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(m => m.Miniature)
            .Include(m => m.MiniState)
            .Include(m => m.Person)
            .Where(m => m.Id == id && m.UserId == userId)
            .FirstOrDefaultAsync());
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
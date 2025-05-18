using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class MiniatureCollectionRepository : BaseRepository<App.DAL.DTO.MiniatureCollection, App.Domain.MiniatureCollection>, IMiniatureCollectionRepository
{
    public MiniatureCollectionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniatureCollectionUOWMapper())
    {
    }
    
    public override async Task<IEnumerable<App.DAL.DTO.MiniatureCollection>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(x => x.Miniature)
            .Include(x => x.MiniState)
            .Include(x => x.Person)
            .Where(x => x.UserId == userId)
            .Select(x => Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<App.DAL.DTO.MiniatureCollection?> FindAsync(Guid id, Guid userId)
    {
        var entity = await RepositoryDbSet
            .Include(x => x.Miniature)
            .Include(x => x.MiniState)
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

        return Mapper.Map(entity);
    }
    
    public async Task<List<MiniatureCollection>> GetAllByUserIdAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Where(mc => mc.UserId == userId)
            .Include(mc => mc.MiniState)
            .ToListAsync();
    }
    
    public async Task<List<App.DAL.DTO.MiniatureCollection>> AllWithPaintSwatchesAsync(Guid userId)
    {
        var domainEntities = await RepositoryDbSet
            .Where(mc => mc.UserId == userId)
            .Include(mc => mc.MiniPaintSwatches)
            .ToListAsync();

        return domainEntities.Select(e => Mapper.Map(e)!).ToList();
    }
}
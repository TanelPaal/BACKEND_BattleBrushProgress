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
}
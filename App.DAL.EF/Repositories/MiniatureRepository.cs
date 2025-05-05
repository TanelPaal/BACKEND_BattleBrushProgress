using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class MiniatureRepository : BaseRepository<App.DAL.DTO.Miniature, App.Domain.Miniature>, IMiniatureRepository
{
    public MiniatureRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniatureMapper())
    {
    }
    
    public async Task<IEnumerable<App.DAL.DTO.Miniature>> AllWithIncludesAsync()
    {
        return (await RepositoryDbSet
            .Include(m => m.MiniFaction)
            .Include(m => m.MiniManufacturer)
            .Include(m => m.MiniProperties)
            .ToListAsync()).Select(e => Mapper.Map(e)!);
    }

    public async Task<App.DAL.DTO.Miniature?> FindWithIncludesAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(m => m.MiniFaction)
            .Include(m => m.MiniManufacturer)
            .Include(m => m.MiniProperties)
            .FirstOrDefaultAsync(m => m.Id == id));
    }
}
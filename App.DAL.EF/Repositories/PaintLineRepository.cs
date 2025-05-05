using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PaintLineRepository : BaseRepository<App.DAL.DTO.PaintLine, App.Domain.PaintLine>, IPaintLineRepository
{
    public PaintLineRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new PaintLineMapper())
    {
    }


    public async Task<IEnumerable<App.DAL.DTO.PaintLine>> AllWithIncludesAsync()
    {
        return (await RepositoryDbSet
            .Include(p => p.Brand)
            .ToListAsync()).Select(e => Mapper.Map(e)!);
    }

    public async Task<App.DAL.DTO.PaintLine?> FindWithIncludesAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(p => p.Brand)
            .FirstOrDefaultAsync(p => p.Id == id));
    }
}
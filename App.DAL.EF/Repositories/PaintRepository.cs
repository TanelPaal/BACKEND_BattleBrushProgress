using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PaintRepository : BaseRepository<App.DAL.DTO.Paint, App.Domain.Paint>, IPaintRepository
{
    public PaintRepository(AppDbContext dbContext) : base(dbContext, new PaintMapper())
    {
    }

    public async Task<IEnumerable<App.DAL.DTO.Paint>> AllWithIncludesAsync()
    {
        return (await RepositoryDbSet
            .Include(p => p.Brand)
            .Include(p => p.PaintLine)
            .Include(p => p.PaintType)
            .ToListAsync()).Select(e => Mapper.Map(e)!);
    }

    public async Task<App.DAL.DTO.Paint?> FindWithIncludesAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(p => p.Brand)
            .Include(p => p.PaintLine)
            .Include(p => p.PaintType)
            .FirstOrDefaultAsync(p => p.Id == id));
    }
}
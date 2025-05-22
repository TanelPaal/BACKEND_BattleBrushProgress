using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class MiniPaintSwatchRepository : BaseRepository<App.DAL.DTO.MiniPaintSwatch, App.Domain.MiniPaintSwatch>, IMiniPaintSwatchRepository
{
    public MiniPaintSwatchRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniPaintSwatchUOWMapper())
    {
    }

    public override async Task<IEnumerable<App.DAL.DTO.MiniPaintSwatch>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(x => x.PersonPaints)
                .ThenInclude(pp => pp.Paint)
            .Include(x => x.MiniatureCollection)
            .Where(x => x.UserId == userId)
            .Select(x => Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<App.DAL.DTO.MiniPaintSwatch?> FindAsync(Guid id, Guid userId)
    {
        var entity = await RepositoryDbSet
            .Include(x => x.MiniatureCollection)
            .Include(x => x.PersonPaints)
                .ThenInclude(pp => pp.Paint)
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

        return Mapper.Map(entity);
    }
}
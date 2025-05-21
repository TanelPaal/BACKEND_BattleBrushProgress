using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PersonPaintsRepository : BaseRepository<App.DAL.DTO.PersonPaints, App.Domain.PersonPaints>, IPersonPaintsRepository
{
    private readonly PersonPaintsUOWMapper _mapper = new PersonPaintsUOWMapper();

    public PersonPaintsRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new PersonPaintsUOWMapper())
    {
    }

    public override async Task<IEnumerable<App.DAL.DTO.PersonPaints>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(x => x.Person)
            .Include(x => x.Paint)
                .ThenInclude(p => p.Brand)
            .Include(x => x.Paint)
                .ThenInclude(p => p.PaintType)
            .Include(x => x.Paint)
                .ThenInclude(p => p.PaintLine)
            .Where(x => x.UserId == userId)
            .Select(x => Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<App.DAL.DTO.PersonPaints?> FindAsync(Guid id, Guid userId)
    {
        var entity = await RepositoryDbSet
            .Include(x => x.Person)
            .Include(x => x.Paint)
                .ThenInclude(p => p.Brand)
            .Include(x => x.Paint)
                .ThenInclude(p => p.PaintType)
            .Include(x => x.Paint)
                .ThenInclude(p => p.PaintLine)
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

        return Mapper.Map(entity);
    }

    public async Task<List<App.DAL.DTO.PersonPaints>> AllWithPaintDetailsAsync(Guid userId)
    {
        var domainEntities = await RepositoryDbSet
            .Where(pp => pp.UserId == userId)
            .Include(pp => pp.Paint)
                .ThenInclude(p => p.Brand)
            .Include(pp => pp.Paint)
                .ThenInclude(p => p.PaintType)
            .ToListAsync();

        // Use the mapper to convert each domain entity to DTO
        return domainEntities.Select(e => _mapper.Map(e)!).ToList();
    }
}
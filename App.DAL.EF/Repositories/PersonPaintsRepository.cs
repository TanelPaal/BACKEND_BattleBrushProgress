using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PersonPaintsRepository : BaseRepository<App.DAL.DTO.PersonPaints, App.Domain.PersonPaints>, IPersonPaintsRepository
{
    public PersonPaintsRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new PersonPaintsUOWMapper())
    {
    }

    public override async Task<IEnumerable<App.DAL.DTO.PersonPaints>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(x => x.Person)
            .Include(x => x.Paint)
            .Where(x => x.UserId == userId)
            .Select(x => Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<App.DAL.DTO.PersonPaints?> FindAsync(Guid id, Guid userId)
    {
        var entity = await RepositoryDbSet
            .Include(x => x.Person)
            .Include(x => x.Paint)
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

        return Mapper.Map(entity);
    }
}
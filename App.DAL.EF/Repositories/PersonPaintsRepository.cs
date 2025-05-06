using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PersonPaintsRepository : BaseBaseRepository<App.DAL.DTO.PersonPaints, App.Domain.PersonPaints>, IPersonPaintsRepository
{
    public PersonPaintsRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new PersonPaintsUOWMapper())
    {
    }
    
    /*public override async Task<IEnumerable<App.DAL.DTO.PersonPaints>> AllAsync(Guid userId = default!)
    {
        return (await RepositoryDbSet
            .Include(p => p.Paint)
            .Include(p => p.Person)
            .Where(p => p.UserId == userId)
            .ToListAsync()).Select(e => UOWMapper.Map(e)!);
    }

    public override async Task<App.DAL.DTO.PersonPaints?> FindAsync(Guid id, Guid userId = default!)
    {
        var entity =  await RepositoryDbSet
            .Include(p => p.Paint)
            .Include(p => p.Person)
            .Include(p => p.MiniPaintSwatches)
            .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
        
        return UOWMapper.Map(entity);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .AnyAsync(p => p.Id == id && p.UserId == userId);
    }

    public async Task RemoveAsync(Guid id, Guid userId)
    {
        var entity = await RepositoryDbSet
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            
        if (entity != null)
        {
            RepositoryDbSet.Remove(entity);
        }
    }*/
}
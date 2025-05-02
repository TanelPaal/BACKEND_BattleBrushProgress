using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PersonPaintsRepository : BaseRepository<PersonPaints>, IPersonPaintsRepository
{
    public PersonPaintsRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
    public override async Task<IEnumerable<PersonPaints>> AllAsync(Guid userId = default!)
    {
        return await RepositoryDbSet
            .Include(p => p.Paint)
            .Include(p => p.Person)
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }

    public override async Task<PersonPaints?> FindAsync(Guid id, Guid userId = default!)
    {
        return await RepositoryDbSet
            .Include(p => p.Paint)
            .Include(p => p.Person)
            .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
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
    }
}
using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PaintLineRepository : BaseRepository<PaintLine>, IPaintLineRepository
{
    public PaintLineRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }


    public async Task<IEnumerable<PaintLine>> AllWithIncludesAsync()
    {
        return await RepositoryDbSet
            .Include(p => p.Brand)
            .ToListAsync();
    }

    public async Task<PaintLine?> FindWithIncludesAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(p => p.Brand)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
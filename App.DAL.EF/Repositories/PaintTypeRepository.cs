using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class PaintTypeRepository : BaseRepository<PaintType>, IPaintTypeRepository
{
    public PaintTypeRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
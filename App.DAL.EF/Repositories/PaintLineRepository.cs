using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class PaintLineRepository : BaseRepository<PaintLine>, IPaintLineRepository
{
    public PaintLineRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class PaintRepository : BaseRepository<Paint>, IPaintRepository
{
    public PaintRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
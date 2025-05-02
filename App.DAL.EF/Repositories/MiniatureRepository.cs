using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniatureRepository : BaseRepository<Miniature>, IMiniatureRepository
{
    public MiniatureRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
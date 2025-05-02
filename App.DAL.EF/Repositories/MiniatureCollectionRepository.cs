using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniatureCollectionRepository : BaseRepository<MiniatureCollection>, IMiniatureCollectionRepository
{
    public MiniatureCollectionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
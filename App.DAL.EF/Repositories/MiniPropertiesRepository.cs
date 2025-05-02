using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniPropertiesRepository : BaseRepository<MiniProperties>, IMiniPropertiesRepository
{
    public MiniPropertiesRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
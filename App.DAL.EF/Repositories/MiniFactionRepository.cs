using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniFactionRepository : BaseRepository<MiniFaction>, IMiniFactionRepository
{
    public MiniFactionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
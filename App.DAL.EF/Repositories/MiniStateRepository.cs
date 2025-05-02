using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniStateRepository : BaseRepository<MiniState>, IMiniStateRepository
{
    public MiniStateRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
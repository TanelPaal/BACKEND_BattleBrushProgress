using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniFactionRepository : BaseRepository<App.DAL.DTO.MiniFaction, App.Domain.MiniFaction>, IMiniFactionRepository
{
    public MiniFactionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniFactionUOWMapper())
    {
    }
    
}
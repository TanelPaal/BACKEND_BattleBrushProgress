using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniStateRepository : BaseRepository<App.DAL.DTO.MiniState, App.Domain.MiniState>, IMiniStateRepository
{
    public MiniStateRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniStateMapper())
    {
    }
    
}
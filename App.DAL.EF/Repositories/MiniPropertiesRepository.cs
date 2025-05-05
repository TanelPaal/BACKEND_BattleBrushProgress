using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniPropertiesRepository : BaseRepository<App.DAL.DTO.MiniProperties, App.Domain.MiniProperties>, IMiniPropertiesRepository
{
    public MiniPropertiesRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniPropertiesMapper())
    {
    }
    
}
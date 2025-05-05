using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniManufacturerRepository : BaseRepository<App.DAL.DTO.MiniManufacturer, App.Domain.MiniManufacturer>, IMiniManufacturerRepository
{
    public MiniManufacturerRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniManufacturerMapper())
    {
    }
    
}
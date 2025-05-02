using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniManufacturerRepository : BaseRepository<MiniManufacturer>, IMiniManufacturerRepository
{
    public MiniManufacturerRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
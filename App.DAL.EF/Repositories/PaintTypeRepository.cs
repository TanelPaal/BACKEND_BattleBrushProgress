using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class PaintTypeRepository : BaseBaseRepository<App.DAL.DTO.PaintType, App.Domain.PaintType>, IPaintTypeRepository
{
    public PaintTypeRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new PaintTypeUOWMapper())
    {
    }
    
}
using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class BrandRepository : BaseBaseRepository<App.DAL.DTO.Brand, App.Domain.Brand>, IBrandRepository
{
    public BrandRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new BrandUOWMapper())
    {
    }
    
}
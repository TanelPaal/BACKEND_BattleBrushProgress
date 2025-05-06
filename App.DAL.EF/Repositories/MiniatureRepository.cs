using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class MiniatureRepository : BaseBaseRepository<App.DAL.DTO.Miniature, App.Domain.Miniature>, IMiniatureRepository
{
    public MiniatureRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniatureUOWMapper())
    {
    }
    
}
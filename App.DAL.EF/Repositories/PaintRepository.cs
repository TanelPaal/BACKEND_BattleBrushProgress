using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PaintRepository : BaseBaseRepository<App.DAL.DTO.Paint, App.Domain.Paint>, IPaintRepository
{
    public PaintRepository(AppDbContext dbContext) : base(dbContext, new PaintUOWMapper())
    {
    }
    
}
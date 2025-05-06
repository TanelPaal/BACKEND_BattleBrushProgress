using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class MiniPaintSwatchRepository : BaseBaseRepository<App.DAL.DTO.MiniPaintSwatch, App.Domain.MiniPaintSwatch>, IMiniPaintSwatchRepository
{
    public MiniPaintSwatchRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MiniPaintSwatchUOWMapper())
    {
    }
}
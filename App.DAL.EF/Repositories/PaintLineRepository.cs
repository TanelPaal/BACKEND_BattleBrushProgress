using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PaintLineRepository : BaseRepository<App.DAL.DTO.PaintLine, App.Domain.PaintLine>, IPaintLineRepository
{
    public PaintLineRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new PaintLineUOWMapper())
    {
    }
}
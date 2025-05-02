using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class MiniPaintSwatchRepository : BaseRepository<MiniPaintSwatch>, IMiniPaintSwatchRepository
{
    public MiniPaintSwatchRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
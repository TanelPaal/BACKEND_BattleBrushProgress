using App.Domain;
using Base.DAL.Contracts;
using PaintLine = App.DAL.DTO.PaintLine;

namespace App.DAL.EF.Mappers;

public class PaintLineMapper : IMapper<App.DAL.DTO.PaintLine, App.Domain.PaintLine>
{
    private readonly BrandMapper _brandMapper = new();
    
    public PaintLine? Map(Domain.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
            // TODO: Figure out how to map or skip
            Brand = entity.Brand != null ? _brandMapper.Map(entity.Brand) : null,
        };
        return res;
    }

    public Domain.PaintLine? Map(PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new Domain.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
            // TODO: Figure out how to map or skip
            Brand = null
        };
        return res;
    }
}
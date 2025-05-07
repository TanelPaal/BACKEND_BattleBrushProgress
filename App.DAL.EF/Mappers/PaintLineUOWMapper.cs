using App.Domain;
using Base.Contracts;
using Base.DAL.Contracts;
using PaintLine = App.DAL.DTO.PaintLine;

namespace App.DAL.EF.Mappers;

public class PaintLineUOWMapper : IMapper<App.DAL.DTO.PaintLine, App.Domain.PaintLine>
{
    //private readonly BrandUOWMapper _brandUOWMapper = new();
    
    public App.DAL.DTO.PaintLine? Map(App.Domain.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
            // TODO: Figure out how to map or skip
            Brand = null,
            //Brand = entity.Brand != null ? _brandUOWMapper.Map(entity.Brand) : null,
        };
        return res;
    }

    public App.Domain.PaintLine? Map(App.DAL.DTO.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
            // TODO: Figure out how to map or skip
            Brand = null,
            //Brand = entity.Brand != null ? _brandUOWMapper.Map(entity.Brand) : null,
        };
        return res;
    }
}
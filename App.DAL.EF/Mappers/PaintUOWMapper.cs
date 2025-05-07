using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PaintUOWMapper : IMapper<App.DAL.DTO.Paint, App.Domain.Paint>
{
    // private readonly BrandUOWMapper _brandUOWMapper = new();
    // private readonly PaintTypeUOWMapper _paintTypeUOWMapper = new();
    // private readonly PaintLineUOWMapper _paintLineUOWMapper = new();
    
    public App.DAL.DTO.Paint? Map(App.Domain.Paint? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            Brand = null,
            //Brand = entity.Brand != null ? _brandUOWMapper.Map(entity.Brand) : null, 
            PaintTypeId = entity.PaintTypeId,
            PaintType = null,
            //PaintType = entity.PaintType != null ? _paintTypeUOWMapper.Map(entity.PaintType) : null,
            PaintLineId = entity.PaintLineId,
            PaintLine = null,
            //PaintLine = entity.PaintLine != null ? _paintLineUOWMapper.Map(entity.PaintLine) : null,
            // PersonPaints = null // Optionally map if needed
        };
        return res;
    }

    public App.Domain.Paint? Map(App.DAL.DTO.Paint? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            Brand = null,
            //Brand = entity.Brand != null ? _brandUOWMapper.Map(entity.Brand) : null, 
            PaintTypeId = entity.PaintTypeId,
            PaintType = null,
            //PaintType = entity.PaintType != null ? _paintTypeUOWMapper.Map(entity.PaintType) : null,
            PaintLineId = entity.PaintLineId,
            PaintLine = null,
            //PaintLine = entity.PaintLine != null ? _paintLineUOWMapper.Map(entity.PaintLine) : null,
            // PersonPaints = null // Optionally map if needed
        };
        return res;
    }
}
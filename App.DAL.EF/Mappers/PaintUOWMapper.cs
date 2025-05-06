using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PaintUOWMapper : IUOWMapper<App.DAL.DTO.Paint, App.Domain.Paint>
{
    private readonly BrandUOWMapper _brandUOWMapper = new();
    private readonly PaintTypeUOWMapper _paintTypeUOWMapper = new();
    private readonly PaintLineUOWMapper _paintLineUOWMapper = new();
    
    public Paint? Map(Domain.Paint? entity)
    {
        if (entity == null) return null;
        var res = new Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            Brand = entity.Brand != null ? _brandUOWMapper.Map(entity.Brand) : null, 
            PaintTypeId = entity.PaintTypeId,
            PaintType = entity.PaintType != null ? _paintTypeUOWMapper.Map(entity.PaintType) : null,
            PaintLineId = entity.PaintLineId,
            PaintLine = entity.PaintLine != null ? _paintLineUOWMapper.Map(entity.PaintLine) : null,
            // PersonPaints = null // Optionally map if needed
        };
        return res;
    }

    public Domain.Paint? Map(Paint? entity)
    {
        if (entity == null) return null;
        var res = new Domain.Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            Brand = null, // Optionally map if needed
            PaintTypeId = entity.PaintTypeId,
            PaintType = null, // Optionally map if needed
            PaintLineId = entity.PaintLineId,
            PaintLine = null, // Optionally map if needed
            // PersonPaints = null // Optionally map if needed
        };
        return res;
    }
}
using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PaintMapper : IMapper<App.DAL.DTO.Paint, App.Domain.Paint>
{
    private readonly BrandMapper _brandMapper = new();
    private readonly PaintTypeMapper _paintTypeMapper = new();
    private readonly PaintLineMapper _paintLineMapper = new();
    
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
            Brand = entity.Brand != null ? _brandMapper.Map(entity.Brand) : null, 
            PaintTypeId = entity.PaintTypeId,
            PaintType = entity.PaintType != null ? _paintTypeMapper.Map(entity.PaintType) : null,
            PaintLineId = entity.PaintLineId,
            PaintLine = entity.PaintLine != null ? _paintLineMapper.Map(entity.PaintLine) : null,
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
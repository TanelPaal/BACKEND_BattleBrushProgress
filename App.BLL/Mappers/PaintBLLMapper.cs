using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class PaintBLLMapper : IBLLMapper<App.BLL.DTO.Paint, App.DAL.DTO.Paint>
{
    private readonly BrandBLLMapper _brandBLLMapper = new();
    private readonly PaintTypeBLLMapper _paintTypeBLLMapper = new();
    private readonly PaintLineBLLMapper _paintLineBLLMapper = new();
    
    public Paint? Map(DTO.Paint? entity)
    {
        if (entity == null) return null;
        var res = new Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            Brand = entity.Brand != null ? _brandBLLMapper.Map(entity.Brand) : null, 
            PaintTypeId = entity.PaintTypeId,
            PaintType = entity.PaintType != null ? _paintTypeBLLMapper.Map(entity.PaintType) : null,
            PaintLineId = entity.PaintLineId,
            PaintLine = entity.PaintLine != null ? _paintLineBLLMapper.Map(entity.PaintLine) : null,
            // PersonPaints = null // Optionally map if needed
        };
        return res;
    }

    public DTO.Paint? Map(Paint? entity)
    {
        if (entity == null) return null;
        var res = new DTO.Paint()
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
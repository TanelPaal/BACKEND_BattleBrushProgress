using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class PaintBLLMapper : IMapper<App.BLL.DTO.Paint, App.DAL.DTO.Paint>
{
    // private readonly BrandBLLMapper _brandBLLMapper = new();
    // private readonly PaintTypeBLLMapper _paintTypeBLLMapper = new();
    // private readonly PaintLineBLLMapper _paintLineBLLMapper = new();
    
    public App.DAL.DTO.Paint? Map(App.BLL.DTO.Paint? entity)
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
            //Brand = entity.Brand != null ? _brandBLLMapper.Map(entity.Brand) : null, 
            PaintTypeId = entity.PaintTypeId,
            PaintType = null,
            //PaintType = entity.PaintType != null ? _paintTypeBLLMapper.Map(entity.PaintType) : null,
            PaintLineId = entity.PaintLineId,
            PaintLine = null,
            //PaintLine = entity.PaintLine != null ? _paintLineBLLMapper.Map(entity.PaintLine) : null,
            // PersonPaints = null // Optionally map if needed
        };
        return res;
    }

    public App.BLL.DTO.Paint? Map(App.DAL.DTO.Paint? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            Brand = null,
            //Brand = entity.Brand != null ? _brandBLLMapper.Map(entity.Brand) : null, 
            PaintTypeId = entity.PaintTypeId,
            PaintType = null,
            //PaintType = entity.PaintType != null ? _paintTypeBLLMapper.Map(entity.PaintType) : null,
            PaintLineId = entity.PaintLineId,
            PaintLine = null,
            //PaintLine = entity.PaintLine != null ? _paintLineBLLMapper.Map(entity.PaintLine) : null,
            // PersonPaints = null // Optionally map if needed
        };
        return res;
    }
}
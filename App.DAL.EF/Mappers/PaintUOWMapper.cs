using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PaintUOWMapper : IMapper<App.DAL.DTO.Paint, App.Domain.Paint>
{
    
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
            PaintTypeId = entity.PaintTypeId,
            PaintType = null,
            PaintLineId = entity.PaintLineId,
            PaintLine = null,
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
            PaintTypeId = entity.PaintTypeId,
            PaintType = null,
            PaintLineId = entity.PaintLineId,
            PaintLine = null,
            // PersonPaints = null // Optionally map if needed
        };
        return res;
    }
}
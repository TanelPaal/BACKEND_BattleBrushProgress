using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class PaintMapper : IMapper<App.DTO.v1.Paint, App.BLL.DTO.Paint>
{
    public Paint? Map(BLL.DTO.Paint? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            PaintTypeId = entity.PaintTypeId,
            PaintLineId = entity.PaintLineId,
        };
        return res;
    }

    public BLL.DTO.Paint? Map(Paint? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            PaintTypeId = entity.PaintTypeId,
            PaintLineId = entity.PaintLineId,
        };
        return res;
    }
    
    public BLL.DTO.Paint Map(PaintCreate entity)
    {
        var res = new BLL.DTO.Paint()
        {
            Id = Guid.NewGuid(),
            Name = entity.Name,
        };
        return res;
    }
}
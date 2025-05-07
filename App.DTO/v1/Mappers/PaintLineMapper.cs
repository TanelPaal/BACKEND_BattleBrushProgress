using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class PaintLineMapper : IMapper<App.DTO.v1.PaintLine, App.BLL.DTO.PaintLine>
{
    public PaintLine? Map(BLL.DTO.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
        };
        return res;
    }

    public BLL.DTO.PaintLine? Map(PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
        };
        return res;
    }
    
    public BLL.DTO.PaintLine Map(PaintLineCreate entity)
    {
        var res = new BLL.DTO.PaintLine()
        {
            Id = Guid.NewGuid(),
            PaintLineName = entity.PaintLineName,
        };
        return res;
    }
}
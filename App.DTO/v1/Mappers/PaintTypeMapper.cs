using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class PaintTypeMapper : IMapper<App.DTO.v1.PaintType, App.BLL.DTO.PaintType>
{
    public PaintType? Map(BLL.DTO.PaintType? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.PaintType()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
        };
        return res;
    }

    public BLL.DTO.PaintType? Map(PaintType? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.PaintType()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
        };
        return res;
    }
        
    public BLL.DTO.PaintType Map(PaintTypeCreate entity)
    {
        var res = new BLL.DTO.PaintType()
        {
            Id = Guid.NewGuid(),
            Name = entity.Name,
            Description = entity.Description,
        };
        return res;
    }
}
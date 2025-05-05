using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PaintTypeMapper : IMapper<App.DAL.DTO.PaintType, App.Domain.PaintType>
{
    public PaintType? Map(Domain.PaintType? entity)
    {
        if (entity == null) return null;
        var res = new PaintType()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            // TODO: Figure out how to map or skip
            // Paints = null
        };
        return res;
    }

    public Domain.PaintType? Map(PaintType? entity)
    {
        if (entity == null) return null;
        var res = new Domain.PaintType()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            // TODO: Figure out how to map or skip
            // Paints = null
        };
        return res;
    }
}
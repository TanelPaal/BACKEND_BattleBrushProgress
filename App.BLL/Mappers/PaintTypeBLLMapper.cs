using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class PaintTypeBLLMapper : IBLLMapper<App.BLL.DTO.PaintType, App.DAL.DTO.PaintType>
{
    public PaintType? Map(DTO.PaintType? entity)
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

    public DTO.PaintType? Map(PaintType? entity)
    {
        if (entity == null) return null;
        var res = new DTO.PaintType()
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
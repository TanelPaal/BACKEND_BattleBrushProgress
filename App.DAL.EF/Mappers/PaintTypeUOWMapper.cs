using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PaintTypeUOWMapper : IMapper<App.DAL.DTO.PaintType, App.Domain.PaintType>
{
    public App.DAL.DTO.PaintType? Map(App.Domain.PaintType? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.PaintType()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
        };
        return res;
    }

    public App.Domain.PaintType? Map(App.DAL.DTO.PaintType? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.PaintType()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
        };
        return res;
    }
}
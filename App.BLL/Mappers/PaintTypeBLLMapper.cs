using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class PaintTypeBLLMapper : IMapper<App.BLL.DTO.PaintType, App.DAL.DTO.PaintType>
{
    public App.DAL.DTO.PaintType? Map(App.BLL.DTO.PaintType? entity)
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

    public App.BLL.DTO.PaintType? Map(App.DAL.DTO.PaintType? entity)
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
}
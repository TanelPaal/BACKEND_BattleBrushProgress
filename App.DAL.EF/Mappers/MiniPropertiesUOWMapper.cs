using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniPropertiesUOWMapper : IMapper<App.DAL.DTO.MiniProperties, App.Domain.MiniProperties>
{
    public App.DAL.DTO.MiniProperties? Map(App.Domain.MiniProperties? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.MiniProperties()
        {
            Id = entity.Id,
            PropertyName = entity.PropertyName,
            PropertyDesc = entity.PropertyDesc,
            // TODO: Figure out how to map or skip
            // Miniatures = null
        };
        return res;
    }

    public App.Domain.MiniProperties? Map(App.DAL.DTO.MiniProperties? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.MiniProperties()
        {
            Id = entity.Id,
            PropertyName = entity.PropertyName,
            PropertyDesc = entity.PropertyDesc,
            // TODO: Figure out how to map or skip
            // Miniatures = null
        };
        return res;
    }
}
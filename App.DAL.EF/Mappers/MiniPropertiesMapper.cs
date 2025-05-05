using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniPropertiesMapper : IMapper<App.DAL.DTO.MiniProperties, App.Domain.MiniProperties>
{
    public MiniProperties? Map(Domain.MiniProperties? entity)
    {
        if (entity == null) return null;
        var res = new MiniProperties()
        {
            Id = entity.Id,
            PropertyName = entity.PropertyName,
            PropertyDesc = entity.PropertyDesc,
            // TODO: Figure out how to map or skip
            // Miniatures = null
        };
        return res;
    }

    public Domain.MiniProperties? Map(MiniProperties? entity)
    {
        if (entity == null) return null;
        var res = new Domain.MiniProperties()
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
using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class MiniPropertiesBLLMapper : IBLLMapper<App.BLL.DTO.MiniProperties, App.DAL.DTO.MiniProperties>
{
    public MiniProperties? Map(DTO.MiniProperties? entity)
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

    public DTO.MiniProperties? Map(MiniProperties? entity)
    {
        if (entity == null) return null;
        var res = new DTO.MiniProperties()
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
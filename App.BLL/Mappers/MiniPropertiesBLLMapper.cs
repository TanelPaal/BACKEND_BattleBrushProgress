using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class MiniPropertiesBLLMapper : IMapper<App.BLL.DTO.MiniProperties, App.DAL.DTO.MiniProperties>
{
    public App.DAL.DTO.MiniProperties? Map(App.BLL.DTO.MiniProperties? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.MiniProperties()
        {
            Id = entity.Id,
            PropertyName = entity.PropertyName,
            PropertyDesc = entity.PropertyDesc,
        };
        return res;
    }

    public App.BLL.DTO.MiniProperties? Map(App.DAL.DTO.MiniProperties? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniProperties()
        {
            Id = entity.Id,
            PropertyName = entity.PropertyName,
            PropertyDesc = entity.PropertyDesc,
        };
        return res;
    }
}
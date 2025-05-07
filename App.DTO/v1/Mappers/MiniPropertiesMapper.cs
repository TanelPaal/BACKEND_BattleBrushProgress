using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class MiniPropertiesMapper : IMapper<App.DTO.v1.MiniProperties, App.BLL.DTO.MiniProperties>
{
    public MiniProperties? Map(BLL.DTO.MiniProperties? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.MiniProperties()
        {
            Id = entity.Id,
            PropertyName = entity.PropertyName,
            PropertyDesc = entity.PropertyDesc,
        };
        return res;
    }

    public BLL.DTO.MiniProperties? Map(MiniProperties? entity)
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
    
    public BLL.DTO.MiniProperties Map(MiniPropertiesCreate entity)
    {
        var res = new BLL.DTO.MiniProperties()
        {
            Id = Guid.NewGuid(),
            PropertyName = entity.PropertyName,
        };
        return res;
    }
}
using System.Text;
using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class MiniatureMapper : IMapper<App.DTO.v1.Miniature, App.BLL.DTO.Miniature>
{
    public Miniature? Map(BLL.DTO.Miniature? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.Miniature()
        {
            Id = entity.Id,
            MiniName = entity.MiniName,
            MiniDesc = entity.MiniDesc,
            MiniFactionId = entity.MiniFactionId,
            MiniPropertiesId = entity.MiniPropertiesId,
            MiniManufacturerId = entity.MiniManufacturerId
        };
        return res;
    }

    public BLL.DTO.Miniature? Map(Miniature? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.Miniature()
        {
            Id = entity.Id,
            MiniName = entity.MiniName,
            MiniDesc = entity.MiniDesc,
            MiniFactionId = entity.MiniFactionId,
            MiniPropertiesId = entity.MiniPropertiesId,
            MiniManufacturerId = entity.MiniManufacturerId
        };
        return res;
    }
    
    public BLL.DTO.Miniature Map(MiniatureCreate entity)
    {
        var res = new BLL.DTO.Miniature()
        {
            Id = Guid.NewGuid(),
            MiniName = entity.MiniName,
        };
        return res;
    }
}
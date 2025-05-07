using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniatureUOWMapper : IMapper<App.DAL.DTO.Miniature, App.Domain.Miniature>
{
    public App.DAL.DTO.Miniature? Map(App.Domain.Miniature? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.Miniature()
        {
            Id = entity.Id,
            MiniName = entity.MiniName,
            MiniDesc = entity.MiniDesc,
            MiniFactionId = entity.MiniFactionId,
            // TODO: Figure out how to map or skip
            MiniFaction = null,
            //MiniFaction = entity.MiniFaction != null ? _miniFactionUOWMapper.Map(entity.MiniFaction) : null,
            MiniPropertiesId = entity.MiniPropertiesId,
            // TODO: Figure out how to map or skip
            MiniProperties = null,
            //MiniProperties = entity.MiniProperties != null ? _miniPropertiesUOWMapper.Map(entity.MiniProperties) : null,
            MiniManufacturerId = entity.MiniManufacturerId,                
            // TODO: Figure out how to map or skip
            MiniManufacturer = null
            //MiniManufacturer = entity.MiniManufacturer != null ? _miniManufacturerUOWMapper.Map(entity.MiniManufacturer) : null,
            // MiniatureCollections = null // Optionally map if needed
        };
        return res;
    }

    public App.Domain.Miniature? Map(App.DAL.DTO.Miniature? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.Miniature()
        {
            Id = entity.Id,
            MiniName = entity.MiniName,
            MiniDesc = entity.MiniDesc,
            MiniFactionId = entity.MiniFactionId,
            // TODO: Figure out how to map or skip
            MiniFaction = null,
            //MiniFaction = entity.MiniFaction != null ? _miniFactionUOWMapper.Map(entity.MiniFaction) : null,
            MiniPropertiesId = entity.MiniPropertiesId,
            // TODO: Figure out how to map or skip
            MiniProperties = null,
            //MiniProperties = entity.MiniProperties != null ? _miniPropertiesUOWMapper.Map(entity.MiniProperties) : null,
            MiniManufacturerId = entity.MiniManufacturerId,                
            // TODO: Figure out how to map or skip
            MiniManufacturer = null
            //MiniManufacturer = entity.MiniManufacturer != null ? _miniManufacturerUOWMapper.Map(entity.MiniManufacturer) : null,
            // MiniatureCollections = null // Optionally map if needed
        };
        return res;
    }
}
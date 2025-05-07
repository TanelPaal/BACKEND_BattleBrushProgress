using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class MiniatureBLLMapper : IMapper<App.BLL.DTO.Miniature, App.DAL.DTO.Miniature>
{
    public App.DAL.DTO.Miniature? Map(App.BLL.DTO.Miniature? entity)
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
            //MiniFaction = entity.MiniFaction != null ? _miniFactionBLLMapper.Map(entity.MiniFaction) : null,
            MiniPropertiesId = entity.MiniPropertiesId,
            // TODO: Figure out how to map or skip
            MiniProperties = null,
            //MiniProperties = entity.MiniProperties != null ? _miniPropertiesBLLMapper.Map(entity.MiniProperties) : null,
            MiniManufacturerId = entity.MiniManufacturerId,                
            // TODO: Figure out how to map or skip
            MiniManufacturer = null,           
            //MiniManufacturer = entity.MiniManufacturer != null ? _miniManufacturerBLLMapper.Map(entity.MiniManufacturer) : null,
            // MiniatureCollections = null // Optionally map if needed
        };
        return res;
    }

    public App.BLL.DTO.Miniature? Map(App.DAL.DTO.Miniature? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.Miniature()
        {
            Id = entity.Id,
            MiniName = entity.MiniName,
            MiniDesc = entity.MiniDesc,
            MiniFactionId = entity.MiniFactionId,
            // TODO: Figure out how to map or skip
            MiniFaction = null,
            //MiniFaction = entity.MiniFaction != null ? _miniFactionBLLMapper.Map(entity.MiniFaction) : null,
            MiniPropertiesId = entity.MiniPropertiesId,
            // TODO: Figure out how to map or skip
            MiniProperties = null,
            //MiniProperties = entity.MiniProperties != null ? _miniPropertiesBLLMapper.Map(entity.MiniProperties) : null,
            MiniManufacturerId = entity.MiniManufacturerId,                
            // TODO: Figure out how to map or skip
            MiniManufacturer = null,           
            //MiniManufacturer = entity.MiniManufacturer != null ? _miniManufacturerBLLMapper.Map(entity.MiniManufacturer) : null,
            // MiniatureCollections = null // Optionally map if needed
        };
        return res;
    }
}
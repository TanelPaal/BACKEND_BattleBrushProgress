using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class MiniatureBLLMapper : IBLLMapper<App.BLL.DTO.Miniature, App.DAL.DTO.Miniature>
{
    private readonly MiniFactionBLLMapper _miniFactionBLLMapper = new();
    private readonly MiniPropertiesBLLMapper _miniPropertiesBLLMapper = new();
    private readonly MiniManufacturerBLLMapper _miniManufacturerBLLMapper = new();
    
    public Miniature? Map(DTO.Miniature? entity)
    {
        if (entity == null) return null;
        var res = new Miniature()
        {
            Id = entity.Id,
            MiniName = entity.MiniName,
            MiniDesc = entity.MiniDesc,
            MiniFactionId = entity.MiniFactionId,
            // TODO: Figure out how to map or skip
            MiniFaction = entity.MiniFaction != null ? _miniFactionBLLMapper.Map(entity.MiniFaction) : null,
            MiniPropertiesId = entity.MiniPropertiesId,
            // TODO: Figure out how to map or skip
            MiniProperties = entity.MiniProperties != null ? _miniPropertiesBLLMapper.Map(entity.MiniProperties) : null,
            MiniManufacturerId = entity.MiniManufacturerId,                
            // TODO: Figure out how to map or skip
            MiniManufacturer = entity.MiniManufacturer != null ? _miniManufacturerBLLMapper.Map(entity.MiniManufacturer) : null,
            // MiniatureCollections = null // Optionally map if needed
        };
        return res;
    }

    public DTO.Miniature? Map(Miniature? entity)
    {
        if (entity == null) return null;
        var res = new DTO.Miniature()
        {
            Id = entity.Id,
            MiniName = entity.MiniName,
            MiniDesc = entity.MiniDesc,
            MiniFactionId = entity.MiniFactionId,
            // TODO: Figure out how to map or skip
            MiniFaction = null,
            MiniPropertiesId = entity.MiniPropertiesId,
            // TODO: Figure out how to map or skip
            MiniProperties = null, // Optionally map if needed
            MiniManufacturerId = entity.MiniManufacturerId,                
            // TODO: Figure out how to map or skip
            MiniManufacturer = null, // Optionally map if needed
            // MiniatureCollections = null // Optionally map if needed
        };
        return res;
    }
}
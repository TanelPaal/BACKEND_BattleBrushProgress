using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniatureUOWMapper : IUOWMapper<App.DAL.DTO.Miniature, App.Domain.Miniature>
{
    private readonly MiniFactionUOWMapper _miniFactionUOWMapper = new();
    private readonly MiniPropertiesUOWMapper _miniPropertiesUOWMapper = new();
    private readonly MiniManufacturerUOWMapper _miniManufacturerUOWMapper = new();
    
    public Miniature? Map(Domain.Miniature? entity)
    {
        if (entity == null) return null;
        var res = new Miniature()
        {
            Id = entity.Id,
            MiniName = entity.MiniName,
            MiniDesc = entity.MiniDesc,
            MiniFactionId = entity.MiniFactionId,
            // TODO: Figure out how to map or skip
            MiniFaction = entity.MiniFaction != null ? _miniFactionUOWMapper.Map(entity.MiniFaction) : null,
            MiniPropertiesId = entity.MiniPropertiesId,
            // TODO: Figure out how to map or skip
            MiniProperties = entity.MiniProperties != null ? _miniPropertiesUOWMapper.Map(entity.MiniProperties) : null,
            MiniManufacturerId = entity.MiniManufacturerId,                
            // TODO: Figure out how to map or skip
            MiniManufacturer = entity.MiniManufacturer != null ? _miniManufacturerUOWMapper.Map(entity.MiniManufacturer) : null,
            // MiniatureCollections = null // Optionally map if needed
        };
        return res;
    }

    public Domain.Miniature? Map(Miniature? entity)
    {
        if (entity == null) return null;
        var res = new Domain.Miniature()
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
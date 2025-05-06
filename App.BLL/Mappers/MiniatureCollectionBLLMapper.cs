using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class MiniatureCollectionBLLMapper : IBLLMapper<App.BLL.DTO.MiniatureCollection, App.DAL.DTO.MiniatureCollection>
{
    private readonly MiniatureBLLMapper _miniatureBLLMapper = new();
    private readonly MiniStateBLLMapper _miniStateBLLMapper = new();
    private readonly PersonBLLMapper _personBLLMapper = new();
    
    public MiniatureCollection? Map(DTO.MiniatureCollection? entity)
    {
        if (entity == null) return null;
        var res = new MiniatureCollection()
        {
            Id = entity.Id,
            CollectionName = entity.CollectionName,
            CollectionDesc = entity.CollectionDesc,
            AcquisitionDate = entity.AcquisitionDate,
            CompletionDate = entity.CompletionDate,
            MiniatureId = entity.MiniatureId,
            Miniature = entity.Miniature != null ? _miniatureBLLMapper.Map(entity.Miniature) : null,
            MiniStateId = entity.MiniStateId,
            MiniState = entity.MiniState != null ? _miniStateBLLMapper.Map(entity.MiniState) : null,
            PersonId = entity.PersonId,
            Person = entity.Person != null ? _personBLLMapper.Map(entity.Person) : null,
            // MiniPaintSwatches = null // Optionally map if needed
        };
        return res;
    }

    public DTO.MiniatureCollection? Map(MiniatureCollection? entity)
    {
        if (entity == null) return null;
        var res = new DTO.MiniatureCollection()
        {
            Id = entity.Id,
            CollectionName = entity.CollectionName,
            CollectionDesc = entity.CollectionDesc,
            AcquisitionDate = entity.AcquisitionDate,
            CompletionDate = entity.CompletionDate,
            MiniatureId = entity.MiniatureId,
            Miniature = null, // Optionally map if needed
            MiniStateId = entity.MiniStateId,
            MiniState = null, // Optionally map if needed
            PersonId = entity.PersonId,
            Person = null, // Optionally map if needed
            // MiniPaintSwatches = null // Optionally map if needed
        };
        return res;
    }
}
using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniatureCollectionMapper : IMapper<App.DAL.DTO.MiniatureCollection, App.Domain.MiniatureCollection>
{
    private readonly MiniatureMapper _miniatureMapper = new();
    private readonly MiniStateMapper _miniStateMapper = new();
    private readonly PersonMapper _personMapper = new();
    
    public MiniatureCollection? Map(Domain.MiniatureCollection? entity)
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
            Miniature = entity.Miniature != null ? _miniatureMapper.Map(entity.Miniature) : null,
            MiniStateId = entity.MiniStateId,
            MiniState = entity.MiniState != null ? _miniStateMapper.Map(entity.MiniState) : null,
            PersonId = entity.PersonId,
            Person = entity.Person != null ? _personMapper.Map(entity.Person) : null,
            // MiniPaintSwatches = null // Optionally map if needed
        };
        return res;
    }

    public Domain.MiniatureCollection? Map(MiniatureCollection? entity)
    {
        if (entity == null) return null;
        var res = new Domain.MiniatureCollection()
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
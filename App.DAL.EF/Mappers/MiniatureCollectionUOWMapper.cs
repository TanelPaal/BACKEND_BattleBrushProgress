using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniatureCollectionUOWMapper : IUOWMapper<App.DAL.DTO.MiniatureCollection, App.Domain.MiniatureCollection>
{
    private readonly MiniatureUOWMapper _miniatureUOWMapper = new();
    private readonly MiniStateUOWMapper _miniStateUOWMapper = new();
    private readonly PersonUOWMapper _personUOWMapper = new();
    
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
            Miniature = entity.Miniature != null ? _miniatureUOWMapper.Map(entity.Miniature) : null,
            MiniStateId = entity.MiniStateId,
            MiniState = entity.MiniState != null ? _miniStateUOWMapper.Map(entity.MiniState) : null,
            PersonId = entity.PersonId,
            Person = entity.Person != null ? _personUOWMapper.Map(entity.Person) : null,
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
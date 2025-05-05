using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniatureCollectionMapper : IMapper<App.DAL.DTO.MiniatureCollection, App.Domain.MiniatureCollection>
{
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
            Miniature = null, // Optionally map if needed
            MiniStateId = entity.MiniStateId,
            MiniState = null, // Optionally map if needed
            PersonId = entity.PersonId,
            Person = null, // Optionally map if needed
            MiniPaintSwatches = null // Optionally map if needed
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
            MiniPaintSwatches = null // Optionally map if needed
        };
        return res;
    }
}
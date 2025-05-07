using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniatureCollectionUOWMapper : IMapper<App.DAL.DTO.MiniatureCollection, App.Domain.MiniatureCollection>
{
    public App.DAL.DTO.MiniatureCollection? Map(App.Domain.MiniatureCollection? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.MiniatureCollection()
        {
            Id = entity.Id,
            CollectionName = entity.CollectionName,
            CollectionDesc = entity.CollectionDesc,
            AcquisitionDate = entity.AcquisitionDate,
            CompletionDate = entity.CompletionDate,
            MiniatureId = entity.MiniatureId,
            Miniature = null,
            //Miniature = entity.Miniature != null ? _miniatureUOWMapper.Map(entity.Miniature) : null,
            MiniStateId = entity.MiniStateId,
            //MiniState = null,
            //MiniState = entity.MiniState != null ? _miniStateUOWMapper.Map(entity.MiniState) : null,
            PersonId = entity.PersonId,
            //Person = null,
            //Person = entity.Person != null ? _personUOWMapper.Map(entity.Person) : null,
            // MiniPaintSwatches = null // Optionally map if needed
        };
        return res;
    }

    public App.Domain.MiniatureCollection? Map(App.DAL.DTO.MiniatureCollection? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.MiniatureCollection()
        {
            Id = entity.Id,
            CollectionName = entity.CollectionName,
            CollectionDesc = entity.CollectionDesc,
            AcquisitionDate = entity.AcquisitionDate,
            CompletionDate = entity.CompletionDate,
            MiniatureId = entity.MiniatureId,
            Miniature = null,
            //Miniature = entity.Miniature != null ? _miniatureUOWMapper.Map(entity.Miniature) : null,
            MiniStateId = entity.MiniStateId,
            //MiniState = null,
            //MiniState = entity.MiniState != null ? _miniStateUOWMapper.Map(entity.MiniState) : null,
            PersonId = entity.PersonId,
            //Person = null,
            //Person = entity.Person != null ? _personUOWMapper.Map(entity.Person) : null,
            // MiniPaintSwatches = null // Optionally map if needed
        };
        return res;
    }
}
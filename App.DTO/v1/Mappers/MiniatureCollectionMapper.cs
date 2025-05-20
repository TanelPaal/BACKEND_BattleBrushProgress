using Base.Contracts;
using App.DTO.v1;

namespace App.DTO.v1.Mappers;

public class MiniatureCollectionMapper : IMapper<App.DTO.v1.MiniatureCollection, App.BLL.DTO.MiniatureCollection>
{
    public App.DTO.v1.MiniatureCollection? Map(BLL.DTO.MiniatureCollection? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.MiniatureCollection()
        {
            Id = entity.Id,
            CollectionName = entity.CollectionName,
            CollectionDesc = entity.CollectionDesc,
            AcquisitionDate = entity.AcquisitionDate,
            CompletionDate = entity.CompletionDate,
            MiniatureId = entity.MiniatureId,
            Miniature = entity.Miniature == null ? null : new App.DTO.v1.Miniature()
            {
                Id = entity.Miniature.Id,
                MiniName = entity.Miniature.MiniName,
                MiniDesc = entity.Miniature.MiniDesc,
                MiniFactionId = entity.Miniature.MiniFactionId,
                MiniPropertiesId = entity.Miniature.MiniPropertiesId,
                MiniManufacturerId = entity.Miniature.MiniManufacturerId,
            },
            MiniStateId = entity.MiniStateId,
            MiniState = entity.MiniState == null ? null : new App.DTO.v1.MiniState()
            {
                Id = entity.MiniState.Id,
                StateName = entity.MiniState.StateName,
                StateDesc = entity.MiniState.StateDesc,
            },
            PersonId = entity.PersonId,
            Person = entity.Person == null ? null : new App.DTO.v1.Person()
            {
                Id = entity.Person.Id,
                PersonName = entity.Person.PersonName,
                
            }
        };
        return res;
    }

    public BLL.DTO.MiniatureCollection? Map(MiniatureCollection? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniatureCollection()
        {
            Id = entity.Id,
            CollectionName = entity.CollectionName,
            CollectionDesc = entity.CollectionDesc,
            AcquisitionDate = entity.AcquisitionDate,
            CompletionDate = entity.CompletionDate,
            MiniatureId = entity.MiniatureId,
            MiniStateId = entity.MiniStateId,
            PersonId = entity.PersonId
        };
        return res;
    }
    
    public BLL.DTO.MiniatureCollection Map(MiniatureCollectionCreate entity)
    {
        var res = new BLL.DTO.MiniatureCollection()
        {
            Id = Guid.NewGuid(),
            CollectionName = entity.CollectionName,
            AcquisitionDate = entity.AcquisitionDate,
            CompletionDate = entity.CompletionDate,
            MiniatureId = entity.MiniatureId,
            MiniStateId = entity.MiniStateId,
            PersonId = entity.PersonId,
        };
        return res;
    }
}
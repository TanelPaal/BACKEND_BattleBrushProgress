using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class MiniatureCollectionBLLMapper : IMapper<App.BLL.DTO.MiniatureCollection, App.DAL.DTO.MiniatureCollection>
{
    public App.DAL.DTO.MiniatureCollection? Map(App.BLL.DTO.MiniatureCollection? entity)
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
            MiniStateId = entity.MiniStateId,
            PersonId = entity.PersonId,
        };
        return res;
    }

    public App.BLL.DTO.MiniatureCollection? Map(App.DAL.DTO.MiniatureCollection? entity)
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
            Miniature = entity.Miniature == null ? null : new App.BLL.DTO.Miniature()
            {
                Id = entity.Miniature!.Id,
                MiniName = entity.Miniature.MiniName,
                MiniDesc = entity.Miniature.MiniDesc,
                MiniFactionId = entity.Miniature.MiniFactionId,
                MiniPropertiesId = entity.Miniature.MiniPropertiesId,
                MiniManufacturerId = entity.Miniature.MiniManufacturerId,
            },
            MiniStateId = entity.MiniStateId,
            MiniState = entity.MiniState == null ? null : new App.BLL.DTO.MiniState()
            {
                Id = entity.MiniState!.Id,
                StateName = entity.MiniState.StateName,
                StateDesc = entity.MiniState.StateDesc,
            },
            PersonId = entity.PersonId,
            Person = entity.Person == null ? null : new App.BLL.DTO.Person()
            {
                Id = entity.Person!.Id,
                PersonName = entity.Person.PersonName,
            },
        };
        return res;
    }
}
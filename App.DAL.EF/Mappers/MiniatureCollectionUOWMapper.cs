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
            Miniature = entity.Miniature == null ? null : new App.DAL.DTO.Miniature()
            {
                Id = entity.Miniature!.Id,
                MiniName = entity.Miniature.MiniName,
                MiniDesc = entity.Miniature.MiniDesc,
                MiniFactionId = entity.Miniature.MiniFactionId,
                MiniPropertiesId = entity.Miniature.MiniPropertiesId,
                MiniManufacturerId = entity.Miniature.MiniManufacturerId,
            },
            MiniStateId = entity.MiniStateId,
            MiniState = entity.MiniState == null ? null : new App.DAL.DTO.MiniState()
            {
                Id = entity.MiniState!.Id,
                StateName = entity.MiniState.StateName,
                StateDesc = entity.MiniState.StateDesc,
            },
            PersonId = entity.PersonId,
            Person = entity.Person == null ? null : new App.DAL.DTO.Person()
            {
                Id = entity.Person!.Id,
                PersonName = entity.Person.PersonName,
            },
            MiniPaintSwatches = entity.MiniPaintSwatches?
                .Select(s => new App.DAL.DTO.MiniPaintSwatch
                {
                    Id = s.Id,
                    UsageType = s.UsageType,
                    Notes = s.Notes,
                }).ToList()
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
            MiniStateId = entity.MiniStateId,
            PersonId = entity.PersonId,
        };
        return res;
    }
}
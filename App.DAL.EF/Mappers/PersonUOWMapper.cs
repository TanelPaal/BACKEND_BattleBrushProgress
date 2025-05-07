using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PersonUOWMapper : IMapper<App.DAL.DTO.Person, App.Domain.Person>
{
    public App.DAL.DTO.Person? Map(App.Domain.Person? entity)
    {
        if (entity == null) return null;
        
        var res = new App.DAL.DTO.Person()
        {
            Id = entity.Id,
            PersonName = entity.PersonName,
            PersonPaints = entity.PersonPaints?.Select(c => new App.DAL.DTO.PersonPaints()
            {
                Id = c.Id,
                Quantity = c.Quantity,
                AcquisitionDate = c.AcquisitionDate,
                PersonId = c.PersonId,
                // TODO: Figure out how to map or skip
                Person = null,
                PaintId = c.PaintId,
                // TODO: Figure out how to map or skip
                Paint = null,
                // TODO: Figure out how to map or skip
                MiniPaintSwatches = null
            }).ToList(),
            MiniatureCollections = entity.MiniatureCollections?.Select(c => new App.DAL.DTO.MiniatureCollection()
            {
                Id = c.Id,
                CollectionName = c.CollectionName,
                CollectionDesc = c.CollectionDesc,
                AcquisitionDate = c.AcquisitionDate,
                CompletionDate = c.CompletionDate,
                MiniatureId = c.MiniatureId,
                // TODO: Figure out how to map or skip
                Miniature = null,
                MiniStateId = c.MiniStateId,
                // TODO: Figure out how to map or skip
                MiniState = null,
                PersonId = c.PersonId,
                // TODO: Figure out how to map or skip
                Person = null,
                // TODO: Figure out how to map or skip
                MiniPaintSwatches = null
            }).ToList()
        };
        return res;
    }

    public App.Domain.Person? Map(App.DAL.DTO.Person? entity)
    {
        if (entity == null) return null;

        var res = new App.Domain.Person()
        {
            Id = entity.Id,
            PersonName = entity.PersonName,
            PersonPaints = entity.PersonPaints?.Select(c => new App.Domain.PersonPaints()
            {
                Id = c.Id,
                Quantity = c.Quantity,
                AcquisitionDate = c.AcquisitionDate,
                PersonId = c.PersonId,
                // TODO: Figure out how to map or skip
                Person = null,
                PaintId = c.PaintId,
                // TODO: Figure out how to map or skip
                Paint = null,
                // TODO: Figure out how to map or skip
                MiniPaintSwatches = null
            }).ToList(),
            MiniatureCollections = entity.MiniatureCollections?.Select(c => new App.Domain.MiniatureCollection()
            {
                Id = c.Id,
                CollectionName = c.CollectionName,
                CollectionDesc = c.CollectionDesc,
                AcquisitionDate = c.AcquisitionDate,
                CompletionDate = c.CompletionDate,
                MiniatureId = c.MiniatureId,
                // TODO: Figure out how to map or skip
                Miniature = null,
                MiniStateId = c.MiniStateId,
                // TODO: Figure out how to map or skip
                MiniState = null,
                PersonId = c.PersonId,
                // TODO: Figure out how to map or skip
                Person = null,
                // TODO: Figure out how to map or skip
                MiniPaintSwatches = null
            }).ToList()
        };
        return res;
    }
}
using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PersonUOWMapper : IUOWMapper<App.DAL.DTO.Person, App.Domain.Person>
{
    public Person? Map(Domain.Person? entity)
    {
        if (entity == null) return null;
        
        var res = new Person()
        {
            Id = entity.Id,
            PersonName = entity.PersonName,
            PersonPaints = entity.PersonPaints?.Select(c => new PersonPaints()
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
            MiniatureCollections = entity.MiniatureCollections?.Select(c => new MiniatureCollection()
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

    public Domain.Person? Map(Person? entity)
    {
        if (entity == null) return null;

        var res = new Domain.Person()
        {
            Id = entity.Id,
            PersonName = entity.PersonName,
            PersonPaints = entity.PersonPaints?.Select(c => new Domain.PersonPaints()
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
            MiniatureCollections = entity.MiniatureCollections?.Select(c => new Domain.MiniatureCollection()
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
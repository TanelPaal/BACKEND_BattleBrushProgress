using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class PersonBLLMapper : IBLLMapper<App.BLL.DTO.Person, App.DAL.DTO.Person>
{
    public Person? Map(DTO.Person? entity)
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

    public DTO.Person? Map(Person? entity)
    {
        if (entity == null) return null;

        var res = new DTO.Person()
        {
            Id = entity.Id,
            PersonName = entity.PersonName,
            PersonPaints = entity.PersonPaints?.Select(c => new DTO.PersonPaints()
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
            MiniatureCollections = entity.MiniatureCollections?.Select(c => new DTO.MiniatureCollection()
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
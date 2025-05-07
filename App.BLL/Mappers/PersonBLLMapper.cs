using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class PersonBLLMapper : IMapper<App.BLL.DTO.Person, App.DAL.DTO.Person>
{
    public App.DAL.DTO.Person? Map(App.BLL.DTO.Person? entity)
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

    public App.BLL.DTO.Person? Map(App.DAL.DTO.Person? entity)
    {
        if (entity == null) return null;
        
        var res = new App.BLL.DTO.Person()
        {
            Id = entity.Id,
            PersonName = entity.PersonName,
            PersonPaints = entity.PersonPaints?.Select(c => new App.BLL.DTO.PersonPaints()
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
            MiniatureCollections = entity.MiniatureCollections?.Select(c => new App.BLL.DTO.MiniatureCollection()
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
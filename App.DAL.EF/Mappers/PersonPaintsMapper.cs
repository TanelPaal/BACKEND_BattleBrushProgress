using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PersonPaintsMapper : IMapper<App.DAL.DTO.PersonPaints, App.Domain.PersonPaints>
{
    public PersonPaints? Map(Domain.PersonPaints? entity)
    {
        throw new NotImplementedException();
        // if (entity == null) return null;
        //
        // var res = new PersonPaints()
        // {
        //     Id = entity.Id,
        //     Quantity = entity.Quantity,
        //     AcquisitionDate = entity.AcquisitionDate,
        //     PersonId = entity.PersonId,
        //     // TODO: Figure out how to map or skip
        //     Person = null,
        //     PaintId = entity.PaintId,
        //     // TODO: Figure out how to map or skip
        //     Paint = null,
        //     MiniPaintSwatches = entity.MiniPaintSwatches?.Select(c => new MiniPaintSwatch()
        //     {
        //         Id = c.Id,
        //         UsageType = c.UsageType,
        //         Notes = c.Notes,
        //         MiniatureCollectionId = c.MiniatureCollectionId,
        //         // TODO: Figure out how to map or skip
        //         MiniatureCollection = null,
        //         PersonPaintsId = c.PersonPaintsId,
        //         // TODO: Figure out how to map or skip
        //         PersonPaints = null,
        //     }).ToList()
        // };
        // return res;
    }

    public Domain.PersonPaints? Map(PersonPaints? entity)
    {
        throw new NotImplementedException();
        // if (entity == null) return null;
        //
        // var res = new Domain.PersonPaints()
        // {
        //     Id = entity.Id,
        //     Quantity = entity.Quantity,
        //     AcquisitionDate = entity.AcquisitionDate,
        //     PersonId = entity.PersonId,
        //     // TODO: Figure out how to map or skip
        //     Person = null,
        //     PaintId = entity.PaintId,
        //     // TODO: Figure out how to map or skip
        //     Paint = null,
        //     MiniPaintSwatches = entity.MiniPaintSwatches?.Select(c => new Domain.MiniPaintSwatch()
        //     {
        //         Id = c.Id,
        //         UsageType = c.UsageType,
        //         Notes = c.Notes,
        //         MiniatureCollectionId = c.MiniatureCollectionId,
        //         // TODO: Figure out how to map or skip
        //         MiniatureCollection = null,
        //         PersonPaintsId = c.PersonPaintsId,
        //         // TODO: Figure out how to map or skip
        //         PersonPaints = null,
        //     }).ToList()
        // };
        // return res;
    }
}
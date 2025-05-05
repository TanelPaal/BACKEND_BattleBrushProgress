using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PersonPaintsMapper : IMapper<App.DAL.DTO.PersonPaints, App.Domain.PersonPaints>
{
    public PersonPaints? Map(Domain.PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            Person = null, // Optionally map if needed
            PaintId = entity.PaintId,
            Paint = null, // Optionally map if needed
            MiniPaintSwatches = null // Optionally map if needed       
        };
        return res;
    }

    public Domain.PersonPaints? Map(PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new Domain.PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            Person = null, // Optionally map if needed
            PaintId = entity.PaintId,
            Paint = null, // Optionally map if needed
            MiniPaintSwatches = null // Optionally map if needed       
        };
        return res;
    }
}
using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PersonPaintsUOWMapper : IUOWMapper<App.DAL.DTO.PersonPaints, App.Domain.PersonPaints>
{
    private readonly PaintUOWMapper _paintUOWMapper = new();
    private readonly PersonUOWMapper _personUOWMapper = new();
    
    public PersonPaints? Map(Domain.PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            Person = entity.Person != null ? _personUOWMapper.Map(entity.Person) : null,
            PaintId = entity.PaintId,
            Paint = entity.Paint != null ? _paintUOWMapper.Map(entity.Paint) : null,
            // MiniPaintSwatches = null // Optionally map if needed       
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
            // MiniPaintSwatches = null // Optionally map if needed       
        };
        return res;
    }
}
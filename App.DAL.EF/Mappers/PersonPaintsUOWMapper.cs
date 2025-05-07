using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PersonPaintsUOWMapper : IMapper<App.DAL.DTO.PersonPaints, App.Domain.PersonPaints>
{
    // private readonly PaintUOWMapper _paintUOWMapper = new();
    // private readonly PersonUOWMapper _personUOWMapper = new();
    
    public App.DAL.DTO.PersonPaints? Map(App.Domain.PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            Person = null, 
            //Person = entity.Person != null ? _personUOWMapper.Map(entity.Person) : null,
            PaintId = entity.PaintId,
            Paint = null,
            //Paint = entity.Paint != null ? _paintUOWMapper.Map(entity.Paint) : null,
            // MiniPaintSwatches = null // Optionally map if needed       
        };
        return res;
    }

    public App.Domain.PersonPaints? Map(App.DAL.DTO.PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            Person = null, 
            //Person = entity.Person != null ? _personUOWMapper.Map(entity.Person) : null,
            PaintId = entity.PaintId,
            Paint = null,
            //Paint = entity.Paint != null ? _paintUOWMapper.Map(entity.Paint) : null,
            // MiniPaintSwatches = null // Optionally map if needed      
        };
        return res;
    }
}
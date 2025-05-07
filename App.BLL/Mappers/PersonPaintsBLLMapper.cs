using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class PersonPaintsBLLMapper : IMapper<App.BLL.DTO.PersonPaints, App.DAL.DTO.PersonPaints>
{
    // private readonly PaintBLLMapper _paintBLLMapper = new();
    // private readonly PersonBLLMapper _personBLLMapper = new();
    
    public App.DAL.DTO.PersonPaints? Map(App.BLL.DTO.PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            Person = null,
            // Person = entity.Person != null ? _personBLLMapper.Map(entity.Person) : null,
            PaintId = entity.PaintId,
            Paint = null,
            // Paint = entity.Paint != null ? _paintBLLMapper.Map(entity.Paint) : null,
            // MiniPaintSwatches = null // Optionally map if needed       
        };
        return res;
    }

    public App.BLL.DTO.PersonPaints? Map(App.DAL.DTO.PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            Person = null,
            // Person = entity.Person != null ? _personBLLMapper.Map(entity.Person) : null,
            PaintId = entity.PaintId,
            Paint = null,
            // Paint = entity.Paint != null ? _paintBLLMapper.Map(entity.Paint) : null,
            // MiniPaintSwatches = null // Optionally map if needed       
        };
        return res;
    }
}
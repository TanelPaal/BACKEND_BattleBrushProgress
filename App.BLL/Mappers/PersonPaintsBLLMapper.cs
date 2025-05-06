using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class PersonPaintsBLLMapper : IBLLMapper<App.BLL.DTO.PersonPaints, App.DAL.DTO.PersonPaints>
{
    private readonly PaintBLLMapper _paintBLLMapper = new();
    private readonly PersonBLLMapper _personBLLMapper = new();
    
    public PersonPaints? Map(DTO.PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            Person = entity.Person != null ? _personBLLMapper.Map(entity.Person) : null,
            PaintId = entity.PaintId,
            Paint = entity.Paint != null ? _paintBLLMapper.Map(entity.Paint) : null,
            // MiniPaintSwatches = null // Optionally map if needed       
        };
        return res;
    }

    public DTO.PersonPaints? Map(PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new DTO.PersonPaints()
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
using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class PersonPaintsMapper : IMapper<App.DTO.v1.PersonPaints, App.BLL.DTO.PersonPaints>
{
    public PersonPaints? Map(BLL.DTO.PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            PaintId = entity.PaintId,
        };
        return res;
    }

    public BLL.DTO.PersonPaints? Map(PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            PaintId = entity.PaintId,
        };
        return res;
    }
    
    public BLL.DTO.PersonPaints Map(PersonPaintsCreate entity)
    {
        var res = new BLL.DTO.PersonPaints()
        {
            Id = Guid.NewGuid(),
            Quantity = entity.Quantity,
        };
        return res;
    }
}
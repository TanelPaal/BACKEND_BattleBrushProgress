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
            Person = entity.Person == null 
                ? null : 
                new App.DTO.v1.Person()
            {
                Id = entity.Person.Id,
                PersonName = entity.Person.PersonName,
            },
            PaintId = entity.PaintId,
            Paint = entity.Paint == null ? null : new App.DTO.v1.Paint()
            {
                Id = entity.PaintId,
                Name = entity.Paint.Name,
                HexCode = entity.Paint.HexCode,
                UPC = entity.Paint.UPC,
                BrandId = entity.Paint.BrandId,
                PaintTypeId = entity.Paint.PaintTypeId,
                PaintLineId = entity.Paint.PaintLineId
            }
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
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            PaintId = entity.PaintId,
        };
        return res;
    }
}
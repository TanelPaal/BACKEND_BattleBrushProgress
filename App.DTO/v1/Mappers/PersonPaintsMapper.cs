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
                ? null 
                : new App.DTO.v1.Person()
                {
                    Id = entity.Person.Id,
                    PersonName = entity.Person.PersonName,
                },
            PaintId = entity.PaintId,
            Paint = entity.Paint == null ? null : new App.DTO.v1.Paint()
            {
                Id = entity.Paint.Id,
                Name = entity.Paint.Name,
                HexCode = entity.Paint.HexCode,
                UPC = entity.Paint.UPC,
                BrandId = entity.Paint.BrandId,
                Brand = entity.Paint.Brand == null ? null : new App.DTO.v1.Brand()
                {
                    Id = entity.Paint.Brand.Id,
                    BrandName = entity.Paint.Brand.BrandName
                },
                PaintTypeId = entity.Paint.PaintTypeId,
                PaintType = entity.Paint.PaintType == null ? null : new App.DTO.v1.PaintType()
                {
                    Id = entity.Paint.PaintType.Id,
                    Name = entity.Paint.PaintType.Name
                },
                PaintLineId = entity.Paint.PaintLineId,
                PaintLine = entity.Paint.PaintLine == null ? null : new App.DTO.v1.PaintLine()
                {
                    Id = entity.Paint.PaintLine.Id,
                    PaintLineName = entity.Paint.PaintLine.PaintLineName
                }
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
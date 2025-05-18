using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PersonPaintsUOWMapper : IMapper<App.DAL.DTO.PersonPaints, App.Domain.PersonPaints>
{
    
    public App.DAL.DTO.PersonPaints? Map(App.Domain.PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            Person = entity.Person == null 
                ? null 
                : new Person()
                {
                    Id = entity.Person.Id,
                    PersonName = entity.Person.PersonName,
                },
            PaintId = entity.PaintId,
            Paint = entity.Paint == null 
                ? null 
                : new Paint()
                {
                    Id = entity.Paint.Id,
                    Name = entity.Paint.Name,
                    Brand = entity.Paint.Brand == null ? null : new Brand()
                    {
                        Id = entity.Paint.Brand.Id,
                        BrandName = entity.Paint.Brand.BrandName
                    },
                    PaintType = entity.Paint.PaintType == null ? null : new PaintType()
                    {
                        Id = entity.Paint.PaintType.Id,
                        Name = entity.Paint.PaintType.Name
                    }
                }
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
            PaintId = entity.PaintId,    
        };
        return res;
    }
}
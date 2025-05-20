using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class PersonPaintsBLLMapper : IMapper<App.BLL.DTO.PersonPaints, App.DAL.DTO.PersonPaints>
{
    public App.DAL.DTO.PersonPaints? Map(App.BLL.DTO.PersonPaints? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.PersonPaints()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            AcquisitionDate = entity.AcquisitionDate,
            PersonId = entity.PersonId,
            PaintId = entity.PaintId,
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
            Person = entity.Paint == null ? null : new App.BLL.DTO.Person()
            {
                Id = entity.Person!.Id,
                PersonName = entity.Person.PersonName,
            },
            PaintId = entity.PaintId,
            Paint = entity.Paint == null ? null : new App.BLL.DTO.Paint()
            {
                Id = entity.Paint.Id,
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
}
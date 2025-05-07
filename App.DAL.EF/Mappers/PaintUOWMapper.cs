using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PaintUOWMapper : IMapper<App.DAL.DTO.Paint, App.Domain.Paint>
{
    
    public App.DAL.DTO.Paint? Map(App.Domain.Paint? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            Brand = entity.Brand == null ? null : new App.DAL.DTO.Brand()
            {
                Id = entity.Brand.Id,
                BrandName = entity.Brand.BrandName,
                HeadquartersLocation = entity.Brand.HeadquartersLocation,
                ContactEmail = entity.Brand.ContactEmail,
                ContactPhone = entity.Brand.ContactPhone,
            },
            PaintTypeId = entity.PaintTypeId,
            PaintType = entity.PaintType == null ? null : new App.DAL.DTO.PaintType()
            {
                Id = entity.PaintType.Id,
                Name = entity.PaintType.Name,
                Description = entity.PaintType.Description,
            },
            PaintLineId = entity.PaintLineId,
            PaintLine = entity.PaintLine == null ? null : new App.DAL.DTO.PaintLine()
            {
                Id = entity.PaintLine.Id,
                PaintLineName = entity.PaintLine.PaintLineName,
                Description = entity.PaintLine.Description
            },
        };
        return res;
    }

    public App.Domain.Paint? Map(App.DAL.DTO.Paint? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            PaintTypeId = entity.PaintTypeId,
            PaintLineId = entity.PaintLineId,
        };
        return res;
    }
}
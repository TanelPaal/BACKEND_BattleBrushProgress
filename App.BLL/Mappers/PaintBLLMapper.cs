using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class PaintBLLMapper : IMapper<App.BLL.DTO.Paint, App.DAL.DTO.Paint>
{
    public App.DAL.DTO.Paint? Map(App.BLL.DTO.Paint? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.Paint()
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

    public App.BLL.DTO.Paint? Map(App.DAL.DTO.Paint? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.Paint()
        {
            Id = entity.Id,
            Name = entity.Name,
            HexCode = entity.HexCode,
            UPC = entity.UPC,
            BrandId = entity.BrandId,
            Brand = entity.Brand == null ? null : new App.BLL.DTO.Brand()
            {
                Id = entity.Brand.Id,
                BrandName = entity.Brand.BrandName,
                HeadquartersLocation = entity.Brand.HeadquartersLocation,
                ContactEmail = entity.Brand.ContactEmail,
                ContactPhone = entity.Brand.ContactPhone,
            },
            PaintTypeId = entity.PaintTypeId,
            PaintType = entity.PaintType == null ? null : new App.BLL.DTO.PaintType()
            {
                Id = entity.PaintType.Id,
                Name = entity.PaintType.Name,
                Description = entity.PaintType.Description,
            },
            PaintLineId = entity.PaintLineId,
            PaintLine = entity.PaintLine == null ? null : new App.BLL.DTO.PaintLine()
            {
                Id = entity.PaintLine.Id,
                PaintLineName = entity.PaintLine.PaintLineName,
                Description = entity.PaintLine.Description
            },
        };
        return res;
    }
}
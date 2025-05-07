using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class PaintLineBLLMapper : IMapper<App.BLL.DTO.PaintLine, App.DAL.DTO.PaintLine>
{
    public App.DAL.DTO.PaintLine? Map(App.BLL.DTO.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
        };
        return res;
    }

    public App.BLL.DTO.PaintLine? Map(App.DAL.DTO.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
            Brand = entity.Brand == null 
                ? null : new App.BLL.DTO.Brand()
                {
                    Id = entity.Brand.Id,
                    BrandName = entity.Brand.BrandName,
                    HeadquartersLocation = entity.Brand.HeadquartersLocation,
                    ContactEmail = entity.Brand.ContactEmail,
                    ContactPhone = entity.Brand.ContactPhone
                }

        };
        return res;
    }
}
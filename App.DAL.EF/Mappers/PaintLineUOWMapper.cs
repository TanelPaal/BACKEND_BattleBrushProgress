using App.Domain;
using Base.Contracts;
using Base.DAL.Contracts;
using PaintLine = App.DAL.DTO.PaintLine;

namespace App.DAL.EF.Mappers;

public class PaintLineUOWMapper : IMapper<App.DAL.DTO.PaintLine, App.Domain.PaintLine>
{
    public App.DAL.DTO.PaintLine? Map(App.Domain.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
            Brand = entity.Brand == null 
                ? null : new App.DAL.DTO.Brand()
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

    public App.Domain.PaintLine? Map(App.DAL.DTO.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,

        };
        return res;
    }
}
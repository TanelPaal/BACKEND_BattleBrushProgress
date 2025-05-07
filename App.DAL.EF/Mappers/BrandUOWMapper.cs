using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class BrandUOWMapper : IMapper<App.DAL.DTO.Brand, App.Domain.Brand>
{
    public App.DAL.DTO.Brand? Map(Domain.Brand? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.Brand()
        {
            Id = entity.Id,
            BrandName = entity.BrandName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
            Paints = null, // Optionally use PaintUOWMapper for Mapping
            PaintLines = null // Optionally use PaintLineUOWMapper for Mapping
        };
        return res;
    }

    public App.Domain.Brand? Map(App.DAL.DTO.Brand? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.Brand()
        {
            Id = entity.Id,
            BrandName = entity.BrandName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
            Paints = null, // Optionally use PaintUOWMapper for Mapping
            PaintLines = null // Optionally use PaintLineUOWMapper for Mapping
        };
        return res;
    }
}
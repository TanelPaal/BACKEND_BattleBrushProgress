using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class BrandMapper : IMapper<App.DAL.DTO.Brand, App.Domain.Brand>
{
    public Brand? Map(Domain.Brand? entity)
    {
        if (entity == null) return null;
        var res = new Brand()
        {
            Id = entity.Id,
            BrandName = entity.BrandName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
            Paints = null, // Optionally use PaintMapper for Mapping
            PaintLines = null // Optionally use PaintLineMapper for Mapping
        };
        return res;
    }

    public Domain.Brand? Map(Brand? entity)
    {
        if (entity == null) return null;
        var res = new Domain.Brand()
        {
            Id = entity.Id,
            BrandName = entity.BrandName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
            Paints = null, // Optionally use PaintMapper for Mapping
            PaintLines = null // Optionally use PaintLineMapper for Mapping
        };
        return res;    }
}
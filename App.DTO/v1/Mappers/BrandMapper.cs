using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class BrandMapper : IMapper<App.DTO.v1.Brand, App.BLL.DTO.Brand>
{
    public App.DTO.v1.Brand? Map(BLL.DTO.Brand? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.Brand()
        {
            Id = entity.Id,
            BrandName = entity.BrandName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone
        };
        return res;
    }

    public BLL.DTO.Brand? Map(Brand? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.Brand()
        {
            Id = entity.Id,
            BrandName = entity.BrandName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone
        };
        return res;
    }

    public App.BLL.DTO.Brand Map(BrandCreate entity)
    {
        var res = new App.BLL.DTO.Brand()
        {
            Id = Guid.NewGuid(),
            BrandName = entity.BrandName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
        };
        return res;
    }
}
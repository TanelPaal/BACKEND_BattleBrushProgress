using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class BrandBLLMapper : IMapper<App.BLL.DTO.Brand, App.DAL.DTO.Brand>
{
    public App.DAL.DTO.Brand? Map(App.BLL.DTO.Brand? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.Brand()
        {
            Id = entity.Id,
            BrandName = entity.BrandName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
            Paints = null, 
            PaintLines = null 
        };
        return res;
    }

    public App.BLL.DTO.Brand? Map(App.DAL.DTO.Brand? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.Brand()
        {
            Id = entity.Id,
            BrandName = entity.BrandName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
            Paints = null, 
            PaintLines = null 
        };
        return res;
    }
}
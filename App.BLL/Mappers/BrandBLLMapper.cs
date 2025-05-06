using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class BrandBLLMapper : IBLLMapper<App.BLL.DTO.Brand, App.DAL.DTO.Brand>
{
    public Brand? Map(DTO.Brand? entity)
    {
        if (entity == null) return null;
        var res = new Brand()
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

    public DTO.Brand? Map(Brand? entity)
    {
        if (entity == null) return null;
        var res = new DTO.Brand()
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
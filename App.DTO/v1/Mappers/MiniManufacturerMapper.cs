using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class MiniManufacturerMapper : IMapper<App.DTO.v1.MiniManufacturer, App.BLL.DTO.MiniManufacturer>
{
    public MiniManufacturer? Map(BLL.DTO.MiniManufacturer? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.MiniManufacturer()
        {
            Id = entity.Id,
            ManufacturerName = entity.ManufacturerName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
        };
        return res;
    }

    public BLL.DTO.MiniManufacturer? Map(MiniManufacturer? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniManufacturer()
        {
            Id = entity.Id,
            ManufacturerName = entity.ManufacturerName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
        };
        return res;
    }
    
    public BLL.DTO.MiniManufacturer Map(MiniManufacturerCreate entity)
    {
        var res = new BLL.DTO.MiniManufacturer()
        {
            Id = Guid.NewGuid(),
            ManufacturerName = entity.ManufacturerName,
        };
        return res;
    }
}
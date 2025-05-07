using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class MiniManufacturerBLLMapper : IMapper<App.BLL.DTO.MiniManufacturer, App.DAL.DTO.MiniManufacturer>
{
    public App.DAL.DTO.MiniManufacturer? Map(App.BLL.DTO.MiniManufacturer? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.MiniManufacturer()
        {
            Id = entity.Id,
            ManufacturerName = entity.ManufacturerName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
            // TODO: Figure out how to map or skip
            // Miniatures = null
        };
        return res;
    }

    public App.BLL.DTO.MiniManufacturer? Map(App.DAL.DTO.MiniManufacturer? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniManufacturer()
        {
            Id = entity.Id,
            ManufacturerName = entity.ManufacturerName,
            HeadquartersLocation = entity.HeadquartersLocation,
            ContactEmail = entity.ContactEmail,
            ContactPhone = entity.ContactPhone,
            // TODO: Figure out how to map or skip
            // Miniatures = null
        };
        return res;
    }
}
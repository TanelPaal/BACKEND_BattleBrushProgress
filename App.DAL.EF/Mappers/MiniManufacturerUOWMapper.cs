using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniManufacturerUOWMapper : IMapper<App.DAL.DTO.MiniManufacturer, App.Domain.MiniManufacturer>
{
    public App.DAL.DTO.MiniManufacturer? Map(App.Domain.MiniManufacturer? entity)
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

    public App.Domain.MiniManufacturer? Map(App.DAL.DTO.MiniManufacturer? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.MiniManufacturer()
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
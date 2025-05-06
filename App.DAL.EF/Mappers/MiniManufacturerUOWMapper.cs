using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniManufacturerUOWMapper : IUOWMapper<App.DAL.DTO.MiniManufacturer, App.Domain.MiniManufacturer>
{
    public MiniManufacturer? Map(Domain.MiniManufacturer? entity)
    {
        if (entity == null) return null;
        var res = new MiniManufacturer()
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

    public Domain.MiniManufacturer? Map(MiniManufacturer? entity)
    {
        if (entity == null) return null;
        var res = new Domain.MiniManufacturer()
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
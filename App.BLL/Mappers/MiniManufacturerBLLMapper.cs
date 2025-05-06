using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class MiniManufacturerBLLMapper : IBLLMapper<App.BLL.DTO.MiniManufacturer, App.DAL.DTO.MiniManufacturer>
{
    public MiniManufacturer? Map(DTO.MiniManufacturer? entity)
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

    public DTO.MiniManufacturer? Map(MiniManufacturer? entity)
    {
        if (entity == null) return null;
        var res = new DTO.MiniManufacturer()
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
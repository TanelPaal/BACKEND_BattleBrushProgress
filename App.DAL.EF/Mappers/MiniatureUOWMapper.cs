using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniatureUOWMapper : IMapper<App.DAL.DTO.Miniature, App.Domain.Miniature>
{
    public App.DAL.DTO.Miniature? Map(App.Domain.Miniature? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.Miniature()
        {
            Id = entity.Id,
            MiniName = entity.MiniName,
            MiniDesc = entity.MiniDesc,
            MiniFactionId = entity.MiniFactionId,
            MiniFaction = entity.MiniFaction == null ? null : new App.DAL.DTO.MiniFaction()
            {
                Id = entity.MiniFaction!.Id,
                FactionName = entity.MiniFaction.FactionName,
                FactionDesc = entity.MiniFaction.FactionDesc,
            },
            MiniPropertiesId = entity.MiniPropertiesId,
            MiniProperties = entity.MiniProperties == null ? null : new App.DAL.DTO.MiniProperties()
            {
                Id = entity.MiniProperties!.Id,
                PropertyName = entity.MiniProperties.PropertyName,
                PropertyDesc = entity.MiniProperties.PropertyDesc,
            },
            MiniManufacturerId = entity.MiniManufacturerId,                
            MiniManufacturer = entity.MiniManufacturer == null ? null : new App.DAL.DTO.MiniManufacturer()
            {
                Id = entity.MiniManufacturer!.Id,
                ManufacturerName = entity.MiniManufacturer.ManufacturerName,
                HeadquartersLocation = entity.MiniManufacturer.HeadquartersLocation,
                ContactEmail = entity.MiniManufacturer.ContactEmail,
                ContactPhone = entity.MiniManufacturer.ContactPhone,
            },           
        };
        return res;
    }

    public App.Domain.Miniature? Map(App.DAL.DTO.Miniature? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.Miniature()
        {
            Id = entity.Id,
            MiniName = entity.MiniName,
            MiniDesc = entity.MiniDesc,
            MiniFactionId = entity.MiniFactionId,
            MiniPropertiesId = entity.MiniPropertiesId,
            MiniManufacturerId = entity.MiniManufacturerId,                
        };
        return res;
    }
}
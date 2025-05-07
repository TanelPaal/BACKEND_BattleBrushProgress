using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class MiniatureCollectionMapper : IMapper<App.DTO.v1.MiniatureCollection, App.BLL.DTO.MiniatureCollection>
{
    public App.DTO.v1.MiniatureCollection? Map(BLL.DTO.MiniatureCollection? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.MiniatureCollection()
        {
            Id = entity.Id,
            CollectionName = entity.CollectionName,
            CollectionDesc = entity.CollectionDesc,
            AcquisitionDate = entity.AcquisitionDate,
            CompletionDate = entity.CompletionDate,
            MiniatureId = entity.MiniatureId,
            MiniStateId = entity.MiniStateId,
            PersonId = entity.PersonId
        };
        return res;
    }

    public BLL.DTO.MiniatureCollection? Map(MiniatureCollection? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniatureCollection()
        {
            Id = entity.Id,
            CollectionName = entity.CollectionName,
            CollectionDesc = entity.CollectionDesc,
            AcquisitionDate = entity.AcquisitionDate,
            CompletionDate = entity.CompletionDate,
            MiniatureId = entity.MiniatureId,
            MiniStateId = entity.MiniStateId,
            PersonId = entity.PersonId
        };
        return res;
    }
    
    public BLL.DTO.MiniatureCollection Map(MiniatureCollectionCreate entity)
    {
        var res = new BLL.DTO.MiniatureCollection()
        {
            Id = Guid.NewGuid(),
            CollectionName = entity.CollectionName
        };
        return res;
    }
}
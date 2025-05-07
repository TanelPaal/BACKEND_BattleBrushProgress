using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class MiniatureCollectionBLLMapper : IMapper<App.BLL.DTO.MiniatureCollection, App.DAL.DTO.MiniatureCollection>
{
    // private readonly MiniatureBLLMapper _miniatureBLLMapper = new();
    // private readonly MiniStateBLLMapper _miniStateBLLMapper = new();
    // private readonly PersonBLLMapper _personBLLMapper = new();
    
    public App.DAL.DTO.MiniatureCollection? Map(App.BLL.DTO.MiniatureCollection? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.MiniatureCollection()
        {
            Id = entity.Id,
            CollectionName = entity.CollectionName,
            CollectionDesc = entity.CollectionDesc,
            AcquisitionDate = entity.AcquisitionDate,
            CompletionDate = entity.CompletionDate,
            MiniatureId = entity.MiniatureId,
            Miniature = null,
            //Miniature = entity.Miniature != null ? _miniatureBLLMapper.Map(entity.Miniature) : null,
            MiniStateId = entity.MiniStateId,
            MiniState = null,
            //MiniState = entity.MiniState != null ? _miniStateBLLMapper.Map(entity.MiniState) : null,
            PersonId = entity.PersonId,
            Person = null,
            //Person = entity.Person != null ? _personBLLMapper.Map(entity.Person) : null,
            // MiniPaintSwatches = null // Optionally map if needed
        };
        return res;
    }

    public App.BLL.DTO.MiniatureCollection? Map(App.DAL.DTO.MiniatureCollection? entity)
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
            Miniature = null,
            //Miniature = entity.Miniature != null ? _miniatureBLLMapper.Map(entity.Miniature) : null,
            MiniStateId = entity.MiniStateId,
            MiniState = null,
            //MiniState = entity.MiniState != null ? _miniStateBLLMapper.Map(entity.MiniState) : null,
            PersonId = entity.PersonId,
            Person = null,
            //Person = entity.Person != null ? _personBLLMapper.Map(entity.Person) : null,
            // MiniPaintSwatches = null // Optionally map if needed
        };
        return res;
    }
}
using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniFactionUOWMapper : IMapper<App.DAL.DTO.MiniFaction, App.Domain.MiniFaction>
{
    public App.DAL.DTO.MiniFaction? Map(App.Domain.MiniFaction? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.MiniFaction()
        {
            Id = entity.Id,
            FactionName = entity.FactionName,
            FactionDesc = entity.FactionDesc,
            // TODO: Figure out how to map or skip
            // Miniatures = null
        };
        return res;
    }

    public App.Domain.MiniFaction? Map(App.DAL.DTO.MiniFaction? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.MiniFaction()
        {
            Id = entity.Id,
            FactionName = entity.FactionName,
            FactionDesc = entity.FactionDesc,
            // TODO: Figure out how to map or skip
            // Miniatures = null
        };
        return res;
    }
}
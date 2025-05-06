using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniFactionUOWMapper : IUOWMapper<App.DAL.DTO.MiniFaction, App.Domain.MiniFaction>
{
    public MiniFaction? Map(Domain.MiniFaction? entity)
    {
        if (entity == null) return null;
        var res = new MiniFaction()
        {
            Id = entity.Id,
            FactionName = entity.FactionName,
            FactionDesc = entity.FactionDesc,
            // TODO: Figure out how to map or skip
            // Miniatures = null
        };
        return res;
    }

    public Domain.MiniFaction? Map(MiniFaction? entity)
    {
        if (entity == null) return null;
        var res = new Domain.MiniFaction()
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
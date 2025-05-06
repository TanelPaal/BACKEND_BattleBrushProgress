using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class MiniFactionBLLMapper : IBLLMapper<App.BLL.DTO.MiniFaction, App.DAL.DTO.MiniFaction>
{
    public MiniFaction? Map(DTO.MiniFaction? entity)
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

    public DTO.MiniFaction? Map(MiniFaction? entity)
    {
        if (entity == null) return null;
        var res = new DTO.MiniFaction()
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
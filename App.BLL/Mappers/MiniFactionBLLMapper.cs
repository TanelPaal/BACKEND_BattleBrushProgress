using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class MiniFactionBLLMapper : IMapper<App.BLL.DTO.MiniFaction, App.DAL.DTO.MiniFaction>
{
    public App.DAL.DTO.MiniFaction? Map(App.BLL.DTO.MiniFaction? entity)
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

    public App.BLL.DTO.MiniFaction? Map(App.DAL.DTO.MiniFaction? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniFaction()
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
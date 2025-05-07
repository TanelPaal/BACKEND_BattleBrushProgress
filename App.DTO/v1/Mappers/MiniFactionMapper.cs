using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class MiniFactionMapper : IMapper<App.DTO.v1.MiniFaction, App.BLL.DTO.MiniFaction>
{
    public MiniFaction? Map(BLL.DTO.MiniFaction? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.MiniFaction()
        {
            Id = entity.Id,
            FactionName = entity.FactionName,
            FactionDesc = entity.FactionDesc
        };
        return res;
    }

    public BLL.DTO.MiniFaction? Map(MiniFaction? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniFaction()
        {
            Id = entity.Id,
            FactionName = entity.FactionName,
            FactionDesc = entity.FactionDesc
        };
        return res;
    }
    
    public BLL.DTO.MiniFaction Map(MiniFactionCreate entity)
    {
        var res = new BLL.DTO.MiniFaction()
        {
            Id = Guid.NewGuid(),
            FactionName = entity.FactionName,
        };
        return res;
    }
}
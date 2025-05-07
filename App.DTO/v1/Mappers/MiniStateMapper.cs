using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class MiniStateMapper : IMapper<App.DTO.v1.MiniState, App.BLL.DTO.MiniState>
{
    public MiniState? Map(BLL.DTO.MiniState? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.MiniState()
        {
            Id = entity.Id,
            StateName = entity.StateName,
            StateDesc = entity.StateDesc,
        };
        return res;
    }

    public BLL.DTO.MiniState? Map(MiniState? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniState()
        {
            Id = entity.Id,
            StateName = entity.StateName,
            StateDesc = entity.StateDesc,
        };
        return res;
    }
    
    public BLL.DTO.MiniState Map(MiniStateCreate entity)
    {
        var res = new BLL.DTO.MiniState()
        {
            Id = Guid.NewGuid(),
            StateName = entity.StateName,
            StateDesc = entity.StateDesc,
        };
        return res;
    }
}
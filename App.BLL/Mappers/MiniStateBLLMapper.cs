using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class MiniStateBLLMapper : IMapper<App.BLL.DTO.MiniState, App.DAL.DTO.MiniState>
{
    public App.DAL.DTO.MiniState? Map(App.BLL.DTO.MiniState? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.MiniState
        {
            Id = entity.Id,
            StateName = entity.StateName,
            StateDesc = entity.StateDesc
        };
        return res;
    }

    public App.BLL.DTO.MiniState? Map(App.DAL.DTO.MiniState? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniState
        {
            Id = entity.Id,
            StateName = entity.StateName,
            StateDesc = entity.StateDesc
        };
        return res;
    }
}
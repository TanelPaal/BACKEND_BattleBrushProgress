using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniStateUOWMapper : IMapper<App.DAL.DTO.MiniState, App.Domain.MiniState>
{
    public App.DAL.DTO.MiniState? Map(App.Domain.MiniState? entity)
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

    public App.Domain.MiniState? Map(App.DAL.DTO.MiniState? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.MiniState
        {
            Id = entity.Id,
            StateName = entity.StateName,
            StateDesc = entity.StateDesc
        };
        return res;
    }
}
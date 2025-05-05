using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniStateMapper : IMapper<App.DAL.DTO.MiniState, App.Domain.MiniState>
{
    public MiniState? Map(Domain.MiniState? entity)
    {
        if (entity == null) return null;
        var res = new MiniState
        {
            Id = entity.Id,
            StateName = entity.StateName,
            StateDesc = entity.StateDesc
        };
        return res;
    }

    public Domain.MiniState? Map(MiniState? entity)
    {
        if (entity == null) return null;
        var res = new Domain.MiniState
        {
            Id = entity.Id,
            StateName = entity.StateName,
            StateDesc = entity.StateDesc
        };
        return res;
    }
}
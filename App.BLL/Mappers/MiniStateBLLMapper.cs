using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class MiniStateBLLMapper : IBLLMapper<App.BLL.DTO.MiniState, App.DAL.DTO.MiniState>
{
    public MiniState? Map(DTO.MiniState? entity)
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

    public DTO.MiniState? Map(MiniState? entity)
    {
        if (entity == null) return null;
        var res = new DTO.MiniState
        {
            Id = entity.Id,
            StateName = entity.StateName,
            StateDesc = entity.StateDesc
        };
        return res;
    }
}
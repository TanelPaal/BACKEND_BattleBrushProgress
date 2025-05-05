using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniStateMapper : IMapper<App.DAL.DTO.MiniState, App.Domain.MiniState>
{
    public MiniState? Map(Domain.MiniState? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.MiniState? Map(MiniState? entity)
    {
        throw new NotImplementedException();
    }
}
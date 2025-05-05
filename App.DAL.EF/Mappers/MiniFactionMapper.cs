using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniFactionMapper : IMapper<App.DAL.DTO.MiniFaction, App.Domain.MiniFaction>
{
    public MiniFaction? Map(Domain.MiniFaction? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.MiniFaction? Map(MiniFaction? entity)
    {
        throw new NotImplementedException();
    }
}
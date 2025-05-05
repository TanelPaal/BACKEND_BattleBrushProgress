using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniPropertiesMapper : IMapper<App.DAL.DTO.MiniProperties, App.Domain.MiniProperties>
{
    public MiniProperties? Map(Domain.MiniProperties? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.MiniProperties? Map(MiniProperties? entity)
    {
        throw new NotImplementedException();
    }
}
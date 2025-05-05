using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniatureMapper : IMapper<App.DAL.DTO.Miniature, App.Domain.Miniature>
{
    public Miniature? Map(Domain.Miniature? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.Miniature? Map(Miniature? entity)
    {
        throw new NotImplementedException();
    }
}
using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniatureCollectionMapper : IMapper<App.DAL.DTO.MiniatureCollection, App.Domain.MiniatureCollection>
{
    public MiniatureCollection? Map(Domain.MiniatureCollection? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.MiniatureCollection? Map(MiniatureCollection? entity)
    {
        throw new NotImplementedException();
    }
}
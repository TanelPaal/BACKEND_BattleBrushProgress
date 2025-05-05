using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PaintTypeMapper : IMapper<App.DAL.DTO.PaintType, App.Domain.PaintType>
{
    public PaintType? Map(Domain.PaintType? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.PaintType? Map(PaintType? entity)
    {
        throw new NotImplementedException();
    }
}
using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class PaintMapper : IMapper<App.DAL.DTO.Paint, App.Domain.Paint>
{
    public Paint? Map(Domain.Paint? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.Paint? Map(Paint? entity)
    {
        throw new NotImplementedException();
    }
}
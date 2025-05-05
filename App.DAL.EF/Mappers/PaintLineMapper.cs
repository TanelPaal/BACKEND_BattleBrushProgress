using App.Domain;
using Base.DAL.Contracts;
using PaintLine = App.DAL.DTO.PaintLine;

namespace App.DAL.EF.Mappers;

public class PaintLineMapper : IMapper<App.DAL.DTO.PaintLine, App.Domain.PaintLine>
{
    public PaintLine? Map(Domain.PaintLine? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.PaintLine? Map(PaintLine? entity)
    {
        throw new NotImplementedException();
    }
}
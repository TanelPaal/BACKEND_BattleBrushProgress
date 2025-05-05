using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniPaintSwatchMapper : IMapper<App.DAL.DTO.MiniPaintSwatch, App.Domain.MiniPaintSwatch>
{
    public MiniPaintSwatch? Map(Domain.MiniPaintSwatch? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.MiniPaintSwatch? Map(MiniPaintSwatch? entity)
    {
        throw new NotImplementedException();
    }
}
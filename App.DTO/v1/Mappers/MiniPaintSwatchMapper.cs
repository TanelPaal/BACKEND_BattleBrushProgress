using Base.Contracts;

namespace App.DTO.v1.Mappers;

public class MiniPaintSwatchMapper : IMapper<App.DTO.v1.MiniPaintSwatch, App.BLL.DTO.MiniPaintSwatch>
{
    public MiniPaintSwatch? Map(BLL.DTO.MiniPaintSwatch? entity)
    {
        if (entity == null) return null;
        var res = new App.DTO.v1.MiniPaintSwatch()
        {
            Id = entity.Id,
            UsageType = entity.UsageType,
            Notes = entity.Notes,
            MiniatureCollectionId = entity.MiniatureCollectionId,
            PersonPaintsId = entity.PersonPaintsId,
        };
        return res;
    }

    public BLL.DTO.MiniPaintSwatch? Map(MiniPaintSwatch? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniPaintSwatch()
        {
            Id = entity.Id,
            UsageType = entity.UsageType,
            Notes = entity.Notes,
            MiniatureCollectionId = entity.MiniatureCollectionId,
            PersonPaintsId = entity.PersonPaintsId,
        };
        return res;
    }
    
    public BLL.DTO.MiniPaintSwatch Map(MiniPaintSwatchCreate entity)
    {
        var res = new BLL.DTO.MiniPaintSwatch()
        {
            Id = Guid.NewGuid(),
            UsageType = entity.UsageType,
        };
        return res;
    }
}
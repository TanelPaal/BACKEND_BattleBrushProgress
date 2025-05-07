using App.DAL.DTO;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniPaintSwatchUOWMapper : IMapper<App.DAL.DTO.MiniPaintSwatch, App.Domain.MiniPaintSwatch>
{
    public App.DAL.DTO.MiniPaintSwatch? Map(App.Domain.MiniPaintSwatch? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.MiniPaintSwatch()
        {
            Id = entity.Id,
            UsageType = entity.UsageType,
            Notes = entity.Notes,
            MiniatureCollectionId = entity.MiniatureCollectionId,
            MiniatureCollection = null,
            PersonPaintsId = entity.PersonPaintsId,
            PersonPaints = null,
        };
        return res;
    }

    public App.Domain.MiniPaintSwatch? Map(App.DAL.DTO.MiniPaintSwatch? entity)
    {
        if (entity == null) return null;
        var res = new App.Domain.MiniPaintSwatch()
        {
            Id = entity.Id,
            UsageType = entity.UsageType,
            Notes = entity.Notes,
            MiniatureCollectionId = entity.MiniatureCollectionId,
            MiniatureCollection = null,
            PersonPaintsId = entity.PersonPaintsId,
            PersonPaints = null,
        };
        return res;
    }
}
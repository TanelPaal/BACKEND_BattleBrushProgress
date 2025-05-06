using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniPaintSwatchUOWMapper : IUOWMapper<App.DAL.DTO.MiniPaintSwatch, App.Domain.MiniPaintSwatch>
{
    private readonly MiniatureCollectionUOWMapper _miniatureCollectionUOWMapper = new();
    private readonly PersonPaintsUOWMapper _personPaintsUOWMapper = new();
    
    public MiniPaintSwatch? Map(Domain.MiniPaintSwatch? entity)
    {
        if (entity == null) return null;
        var res = new MiniPaintSwatch()
        {
            Id = entity.Id,
            UsageType = entity.UsageType,
            Notes = entity.Notes,
            MiniatureCollectionId = entity.MiniatureCollectionId,
            MiniatureCollection = entity.MiniatureCollection != null ? _miniatureCollectionUOWMapper.Map(entity.MiniatureCollection) : null,
            PersonPaintsId = entity.PersonPaintsId,
            PersonPaints = entity.PersonPaints != null ? _personPaintsUOWMapper.Map(entity.PersonPaints) : null,    
        };
        return res;
    }

    public Domain.MiniPaintSwatch? Map(MiniPaintSwatch? entity)
    {
        if (entity == null) return null;
        var res = new Domain.MiniPaintSwatch()
        {
            Id = entity.Id,
            UsageType = entity.UsageType,
            Notes = entity.Notes,
            MiniatureCollectionId = entity.MiniatureCollectionId,
            MiniatureCollection = null, // Optionally map if needed
            PersonPaintsId = entity.PersonPaintsId,
            PersonPaints = null // Optionally map if needed       
        };
        return res;
    }
}
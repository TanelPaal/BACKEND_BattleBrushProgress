using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class MiniPaintSwatchBLLMapper : IBLLMapper<App.BLL.DTO.MiniPaintSwatch, App.DAL.DTO.MiniPaintSwatch>
{
    private readonly MiniatureCollectionBLLMapper _miniatureCollectionBLLMapper = new();
    private readonly PersonPaintsBLLMapper _personPaintsBLLMapper = new();
    
    public MiniPaintSwatch? Map(DTO.MiniPaintSwatch? entity)
    {
        if (entity == null) return null;
        var res = new MiniPaintSwatch()
        {
            Id = entity.Id,
            UsageType = entity.UsageType,
            Notes = entity.Notes,
            MiniatureCollectionId = entity.MiniatureCollectionId,
            MiniatureCollection = entity.MiniatureCollection != null ? _miniatureCollectionBLLMapper.Map(entity.MiniatureCollection) : null,
            PersonPaintsId = entity.PersonPaintsId,
            PersonPaints = entity.PersonPaints != null ? _personPaintsBLLMapper.Map(entity.PersonPaints) : null,    
        };
        return res;
    }

    public DTO.MiniPaintSwatch? Map(MiniPaintSwatch? entity)
    {
        if (entity == null) return null;
        var res = new DTO.MiniPaintSwatch()
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
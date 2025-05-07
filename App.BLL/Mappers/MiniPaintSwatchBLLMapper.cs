using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class MiniPaintSwatchBLLMapper : IMapper<App.BLL.DTO.MiniPaintSwatch, App.DAL.DTO.MiniPaintSwatch>
{
    public App.DAL.DTO.MiniPaintSwatch? Map(App.BLL.DTO.MiniPaintSwatch? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.MiniPaintSwatch()
        {
            Id = entity.Id,
            UsageType = entity.UsageType,
            Notes = entity.Notes,
            MiniatureCollectionId = entity.MiniatureCollectionId,
            MiniatureCollection = null,
            //MiniatureCollection = entity.MiniatureCollection != null ? _miniatureCollectionBLLMapper.Map(entity.MiniatureCollection) : null,
            PersonPaintsId = entity.PersonPaintsId,
            PersonPaints = null,
            //PersonPaints = entity.PersonPaints != null ? _personPaintsBLLMapper.Map(entity.PersonPaints) : null,    
        };
        return res;
    }

    public App.BLL.DTO.MiniPaintSwatch? Map(App.DAL.DTO.MiniPaintSwatch? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.MiniPaintSwatch()
        {
            Id = entity.Id,
            UsageType = entity.UsageType,
            Notes = entity.Notes,
            MiniatureCollectionId = entity.MiniatureCollectionId,
            MiniatureCollection = null,
            //MiniatureCollection = entity.MiniatureCollection != null ? _miniatureCollectionBLLMapper.Map(entity.MiniatureCollection) : null,
            PersonPaintsId = entity.PersonPaintsId,
            PersonPaints = null,
            //PersonPaints = entity.PersonPaints != null ? _personPaintsBLLMapper.Map(entity.PersonPaints) : null,        
        };
        return res;
    }
}
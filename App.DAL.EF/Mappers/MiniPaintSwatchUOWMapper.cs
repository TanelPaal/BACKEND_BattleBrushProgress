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
            MiniatureCollection = entity.MiniatureCollection == null ? null : new App.DAL.DTO.MiniatureCollection()
            {
                Id = entity.MiniatureCollection!.Id,
                CollectionName = entity.MiniatureCollection.CollectionName,
                CollectionDesc = entity.MiniatureCollection.CollectionDesc,
                AcquisitionDate = entity.MiniatureCollection.AcquisitionDate,
                CompletionDate = entity.MiniatureCollection.CompletionDate,
                MiniatureId = entity.MiniatureCollection.MiniatureId,
                MiniStateId = entity.MiniatureCollection.MiniStateId,
                PersonId = entity.MiniatureCollection.PersonId,
            },
            PersonPaintsId = entity.PersonPaintsId,
            PersonPaints = entity.PersonPaints == null ? null : new App.DAL.DTO.PersonPaints()
            {
                Id = entity.PersonPaints!.Id,
                Quantity = entity.PersonPaints.Quantity,
                AcquisitionDate = entity.PersonPaints.AcquisitionDate,
                PersonId = entity.PersonPaints.PersonId,
                PaintId = entity.PersonPaints.PaintId,
                Paint = entity.PersonPaints.Paint == null ? null : new App.DAL.DTO.Paint
                {
                    Id = entity.PersonPaints.Paint.Id,
                    Name = entity.PersonPaints.Paint.Name,
                    HexCode = entity.PersonPaints.Paint.HexCode,
                    UPC = entity.PersonPaints.Paint.UPC,
                    BrandId = entity.PersonPaints.Paint.BrandId,
                    PaintTypeId = entity.PersonPaints.Paint.PaintTypeId,
                    PaintLineId = entity.PersonPaints.Paint.PaintLineId,
                }
            }
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
            PersonPaintsId = entity.PersonPaintsId,
        };
        return res;
    }
}
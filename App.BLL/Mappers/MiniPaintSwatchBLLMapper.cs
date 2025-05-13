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
            PersonPaintsId = entity.PersonPaintsId,
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
            MiniatureCollection = entity.MiniatureCollection == null ? null : new App.BLL.DTO.MiniatureCollection()
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
            PersonPaints = entity.PersonPaints == null ? null : new App.BLL.DTO.PersonPaints()
            {
                Id = entity.PersonPaints!.Id,
                Quantity = entity.PersonPaints.Quantity,
                AcquisitionDate = entity.PersonPaints.AcquisitionDate,
                PersonId = entity.PersonPaints.PersonId,
                PaintId = entity.PersonPaints.PaintId,
                Paint = entity.PersonPaints.Paint == null ? null : new App.BLL.DTO.Paint
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
}
using App.DAL.DTO;
using Base.BLL.Contracts;

namespace App.BLL.Mappers;

public class PaintLineBLLMapper : IBLLMapper<App.BLL.DTO.PaintLine, App.DAL.DTO.PaintLine>
{
    private readonly BrandBLLMapper _brandBLLMapper = new();
    
    public PaintLine? Map(DTO.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
            // TODO: Figure out how to map or skip
            Brand = entity.Brand != null ? _brandBLLMapper.Map(entity.Brand) : null,
        };
        return res;
    }

    public DTO.PaintLine? Map(PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new DTO.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
            // TODO: Figure out how to map or skip
            Brand = null
        };
        return res;
    }
}
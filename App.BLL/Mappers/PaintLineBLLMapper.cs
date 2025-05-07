using App.DAL.DTO;
using Base.BLL.Contracts;
using Base.Contracts;

namespace App.BLL.Mappers;

public class PaintLineBLLMapper : IMapper<App.BLL.DTO.PaintLine, App.DAL.DTO.PaintLine>
{
    // private readonly BrandBLLMapper _brandBLLMapper = new();
    
    public App.DAL.DTO.PaintLine? Map(App.BLL.DTO.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new App.DAL.DTO.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
            // TODO: Figure out how to map or skip
            Brand = null,
            // Brand = entity.Brand != null ? _brandBLLMapper.Map(entity.Brand) : null,
        };
        return res;
    }

    public App.BLL.DTO.PaintLine? Map(App.DAL.DTO.PaintLine? entity)
    {
        if (entity == null) return null;
        var res = new App.BLL.DTO.PaintLine()
        {
            Id = entity.Id,
            PaintLineName = entity.PaintLineName,
            Description = entity.Description,
            BrandId = entity.BrandId,
            // TODO: Figure out how to map or skip
            Brand = null,
            // Brand = entity.Brand != null ? _brandBLLMapper.Map(entity.Brand) : null,
        };
        return res;
    }
}
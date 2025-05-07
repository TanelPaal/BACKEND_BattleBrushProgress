using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class MiniPaintSwatchService : BaseService<App.BLL.DTO.MiniPaintSwatch, App.DAL.DTO.MiniPaintSwatch, App.DAL.Contracts.IMiniPaintSwatchRepository>, IMiniPaintSwatchService
{
    public MiniPaintSwatchService(
        IAppUOW serviceUOW,
        IMapper<DTO.MiniPaintSwatch, MiniPaintSwatch> mapper) : base(serviceUOW, serviceUOW.MiniPaintSwatchRepository, mapper)
    {
    }
}
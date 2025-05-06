using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class PaintTypeService : BaseService<App.BLL.DTO.PaintType, App.DAL.DTO.PaintType, App.DAL.Contracts.IPaintTypeRepository>, IPaintTypeService
{
    public PaintTypeService(
        IAppUOW serviceUOW, 
        IBLLMapper<DTO.PaintType, PaintType> bllMapper) : base(serviceUOW, serviceUOW.PaintTypeRepository, bllMapper)
    {
    }
}
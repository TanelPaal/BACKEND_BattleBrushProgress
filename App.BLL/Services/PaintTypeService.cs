using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class PaintTypeService : BaseService<App.BLL.DTO.PaintType, App.DAL.DTO.PaintType, App.DAL.Contracts.IPaintTypeRepository>, IPaintTypeService
{
    public PaintTypeService(
        IAppUOW serviceUOW, 
        IMapper<DTO.PaintType, PaintType> mapper) : base(serviceUOW, serviceUOW.PaintTypeRepository, mapper)
    {
    }
}
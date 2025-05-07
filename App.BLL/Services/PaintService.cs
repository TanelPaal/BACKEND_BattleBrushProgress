using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class PaintService : BaseService<App.BLL.DTO.Paint, App.DAL.DTO.Paint, App.DAL.Contracts.IPaintRepository>, IPaintService
{
    public PaintService(
        IAppUOW serviceUOW,  
        IMapper<DTO.Paint, Paint> mapper) : base(serviceUOW, serviceUOW.PaintRepository, mapper)
    {
    }
}
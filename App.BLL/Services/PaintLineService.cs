using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class PaintLineService : BaseService<App.BLL.DTO.PaintLine, App.DAL.DTO.PaintLine, App.DAL.Contracts.IPaintLineRepository>, IPaintLineService
{
    public PaintLineService(
        IAppUOW serviceUOW, 
        IBLLMapper<DTO.PaintLine, PaintLine> bllMapper) : base(serviceUOW, serviceUOW.PaintLineRepository, bllMapper)
    {
    }
}
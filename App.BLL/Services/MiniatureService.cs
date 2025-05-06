using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class MiniatureService : BaseService<App.BLL.DTO.Miniature, App.DAL.DTO.Miniature, App.DAL.Contracts.IMiniatureRepository>, IMiniatureService
{
    public MiniatureService(
        IAppUOW serviceUOW, 
        IBLLMapper<DTO.Miniature, Miniature> bllMapper) : base(serviceUOW, serviceUOW.MiniatureRepository, bllMapper)
    {
    }
}
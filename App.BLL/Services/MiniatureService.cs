using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class MiniatureService : BaseService<App.BLL.DTO.Miniature, App.DAL.DTO.Miniature, App.DAL.Contracts.IMiniatureRepository>, IMiniatureService
{
    public MiniatureService(
        IAppUOW serviceUOW, 
        IMapper<DTO.Miniature, Miniature> mapper) : base(serviceUOW, serviceUOW.MiniatureRepository, mapper)
    {
    }
}
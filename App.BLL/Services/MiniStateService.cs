using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class MiniStateService : BaseService<App.BLL.DTO.MiniState, App.DAL.DTO.MiniState, App.DAL.Contracts.IMiniStateRepository>, IMiniStateService
{
    public MiniStateService(
        IAppUOW serviceUOW, 
        IMapper<DTO.MiniState, MiniState> mapper) : base(serviceUOW, serviceUOW.MiniStateRepository, mapper)
    {
    }
}
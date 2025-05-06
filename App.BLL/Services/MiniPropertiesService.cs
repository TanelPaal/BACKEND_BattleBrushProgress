using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class MiniPropertiesService : BaseService<App.BLL.DTO.MiniProperties, App.DAL.DTO.MiniProperties, App.DAL.Contracts.IMiniPropertiesRepository>, IMiniPropertiesService
{
    public MiniPropertiesService(
        IAppUOW serviceUOW,
        IBLLMapper<DTO.MiniProperties, MiniProperties> bllMapper) : base(serviceUOW, serviceUOW.MiniPropertiesRepository, bllMapper)
    {
    }
}
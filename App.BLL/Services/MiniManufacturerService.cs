using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class MiniManufacturerService : BaseService<App.BLL.DTO.MiniManufacturer, App.DAL.DTO.MiniManufacturer, App.DAL.Contracts.IMiniManufacturerRepository>, IMiniManufacturerService
{
    public MiniManufacturerService(
        IAppUOW serviceUOW,
        IMapper<DTO.MiniManufacturer, MiniManufacturer> mapper) : base(serviceUOW, serviceUOW.MiniManufacturerRepository, mapper)
    {
    }
}
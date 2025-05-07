using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class MiniFactionService : BaseService<App.BLL.DTO.MiniFaction, App.DAL.DTO.MiniFaction, App.DAL.Contracts.IMiniFactionRepository>, IMiniFactionService
{
    public MiniFactionService(
        IAppUOW serviceUOW,
        IMapper<DTO.MiniFaction, MiniFaction> mapper) : base(serviceUOW, serviceUOW.MiniFactionRepository, mapper)
    {
    }
}
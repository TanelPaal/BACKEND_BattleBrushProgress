using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class MiniFactionService : BaseService<App.BLL.DTO.MiniFaction, App.DAL.DTO.MiniFaction, App.DAL.Contracts.IMiniFactionRepository>, IMiniFactionService
{
    public MiniFactionService(
        IAppUOW serviceUOW,
        IBLLMapper<DTO.MiniFaction, MiniFaction> bllMapper) : base(serviceUOW, serviceUOW.MiniFactionRepository, bllMapper)
    {
    }
}
using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class MiniatureCollectionService : BaseService<App.BLL.DTO.MiniatureCollection, App.DAL.DTO.MiniatureCollection, App.DAL.Contracts.IMiniatureCollectionRepository>, IMiniatureCollectionService
{
    public MiniatureCollectionService(
        IAppUOW serviceUOW, 
        IBLLMapper<DTO.MiniatureCollection, MiniatureCollection> bllMapper) : base(serviceUOW, serviceUOW.MiniatureCollectionRepository, bllMapper)
    {
    }
}
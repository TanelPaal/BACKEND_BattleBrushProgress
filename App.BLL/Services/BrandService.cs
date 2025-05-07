using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class BrandService : BaseService<App.BLL.DTO.Brand, App.DAL.DTO.Brand, App.DAL.Contracts.IBrandRepository>, IBrandService
{
    public BrandService(
        IAppUOW serviceUOW,
        IMapper<DTO.Brand, Brand> mapper) : base(serviceUOW, serviceUOW.BrandRepository, mapper)
    {
    }
}
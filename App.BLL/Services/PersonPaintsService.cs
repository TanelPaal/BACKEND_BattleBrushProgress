using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DAL.DTO;
using Base.BLL;
using Base.BLL.Contracts;
using Base.DAL.Contracts;

namespace App.BLL.Services;

public class PersonPaintsService : BaseService<App.BLL.DTO.PersonPaints, App.DAL.DTO.PersonPaints, App.DAL.Contracts.IPersonPaintsRepository>, IPersonPaintsService
{
    public PersonPaintsService(
        IAppUOW serviceUOW, 
        IBLLMapper<DTO.PersonPaints, PersonPaints> bllMapper) : base(serviceUOW, serviceUOW.PersonPaintsRepository, bllMapper)
    {
    }
}
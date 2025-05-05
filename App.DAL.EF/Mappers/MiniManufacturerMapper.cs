using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class MiniManufacturerMapper : IMapper<App.DAL.DTO.MiniManufacturer, App.Domain.MiniManufacturer>
{
    public MiniManufacturer? Map(Domain.MiniManufacturer? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.MiniManufacturer? Map(MiniManufacturer? entity)
    {
        throw new NotImplementedException();
    }
}
using App.DAL.DTO;
using Base.DAL.Contracts;

namespace App.DAL.EF.Mappers;

public class BrandMapper : IMapper<App.DAL.DTO.Brand, App.Domain.Brand>
{
    public Brand? Map(Domain.Brand? entity)
    {
        throw new NotImplementedException();
    }

    public Domain.Brand? Map(Brand? entity)
    {
        throw new NotImplementedException();
    }
}
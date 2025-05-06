using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PersonPaintsRepository : BaseBaseRepository<App.DAL.DTO.PersonPaints, App.Domain.PersonPaints>, IPersonPaintsRepository
{
    public PersonPaintsRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new PersonPaintsUOWMapper())
    {
    }
}
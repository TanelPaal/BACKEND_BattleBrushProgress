using App.DAL.Contracts;
using App.Domain;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class PersonPaintsRepository : BaseRepository<PersonPaints>, IPersonPaintsRepository
{
    public PersonPaintsRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
    {
    }
    
}
﻿using App.DAL.Contracts;
using App.DAL.EF.Mappers;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class PersonRepository : BaseBaseRepository<App.DAL.DTO.Person, App.Domain.Person>, IPersonRepository
{
    public PersonRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new PersonUOWMapper())
    {
    }
}
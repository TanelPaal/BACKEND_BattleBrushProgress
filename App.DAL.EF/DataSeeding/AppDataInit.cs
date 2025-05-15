using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.DataSeeding;

public static class AppDataInit
{
    public static void SeedAppData(AppDbContext context)
    {
        // Seed in the correct order so relationships can be established
        SeedBrands(context);
        SeedPaintLines(context);
        SeedPaintTypes(context);
        SeedPaints(context);
        
        SeedMiniStates(context);
        
        SeedMiniFactions(context);
        SeedMiniManufacturers(context);
        SeedMiniProperties(context);
        // TODO: FK constraint issue
        /*SeedMiniatures(context);*/



    }

    public static void MigrateDatabase(AppDbContext context)
    {
        context.Database.Migrate();
    }

    public static void DeleteDatabase(AppDbContext context)
    {
        context.Database.EnsureDeleted();
    }
    
     public static void SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        foreach (var (roleName, id) in InitialData.Roles)
        {
            var role = roleManager.FindByNameAsync(roleName).Result;

            if (role != null) continue;

            role = new AppRole()
            {
                Id = id ?? Guid.NewGuid(),
                Name = roleName,
            };

            var result = roleManager.CreateAsync(role).Result;
            if (!result.Succeeded)
            {
                throw new ApplicationException("Role creation failed!");
            }
        }


        foreach (var userInfo in InitialData.Users)
        {
            var user = userManager.FindByEmailAsync(userInfo.name).Result;
            if (user == null)
            {
                user = new AppUser()
                {
                    Id = userInfo.id ?? Guid.NewGuid(),
                    Email = userInfo.name,
                    UserName = userInfo.name,
                    EmailConfirmed = true,
                    FirstName = userInfo.firstName,
                    LastName = userInfo.lastName,
                };
                var result = userManager.CreateAsync(user, userInfo.password).Result;
                if (!result.Succeeded)
                {
                    throw new ApplicationException("User creation failed!");
                }
            }

            foreach (var role in userInfo.roles)
            {
                if (userManager.IsInRoleAsync(user, role).Result)
                {
                    Console.WriteLine($"User {user.UserName} already in role {role}");
                    continue;
                }
                
                var roleResult = userManager.AddToRoleAsync(user, role).Result;
                if (!roleResult.Succeeded)
                {
                    foreach (var error in roleResult.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
                else
                {
                    Console.WriteLine($"User {user.UserName} added to role {role}");
                }
            }
        }
    }

    private static void SeedBrands(AppDbContext context)
    {
        if (context.Brands.Any()) return;
        
        foreach (var brandData in InitialData.Brands)
        {
            var brand = new Brand
            {
                Id = brandData.id,
                BrandName = brandData.brandName,
                HeadquartersLocation = brandData.headquartersLocation,
                ContactEmail = brandData.contactEmail,
                ContactPhone = brandData.contactPhone
            };
        
            context.Brands.Add(brand);
        }
    
        context.SaveChanges();

    }
    
    private static void SeedPaintLines(AppDbContext context)
    {
        if (context.PaintLines.Any()) return;
    
        foreach (var lineData in InitialData.PaintLines)
        {
            var paintLine = new PaintLine
            {
                Id = lineData.id,
                PaintLineName = lineData.paintLineName,
                Description = lineData.description,
                BrandId = lineData.brandId // Use the predefined brand ID
            };
        
            context.PaintLines.Add(paintLine);
        }
    
        context.SaveChanges();
    }
    
    private static void SeedPaintTypes(AppDbContext context)
    {
        if (context.PaintTypes.Any()) return;
    
        foreach (var typeData in InitialData.PaintTypes)
        {
            var paintType = new PaintType
            {
                Id = typeData.id,
                Name = typeData.paintTypeName,
                Description = typeData.paintTypeDesc,
            };
        
            context.PaintTypes.Add(paintType);
        }
    
        context.SaveChanges();
    }
    
    private static void SeedPaints(AppDbContext context)
    {
        if (context.Paints.Any()) return;
    
        foreach (var paintData in InitialData.Paints)
        {
            var paints = new Paint
            {
                Name = paintData.paintName,
                HexCode = paintData.hexCode,
                UPC = paintData.upc,
                BrandId = paintData.brandb,
                PaintTypeId = paintData.painttype,
                PaintLineId = paintData.paintline
            };
        
            context.Paints.Add(paints);
        }
    
        context.SaveChanges();
    }
    
    private static void SeedMiniStates(AppDbContext context)
    {
        if (context.MiniStates.Any()) return;
    
        foreach (var stateData in InitialData.MiniStates)
        {
            var miniState = new MiniState
            {
                StateName = stateData.stateName,
                StateDesc = stateData.stateDesc,
            };
        
            context.MiniStates.Add(miniState);
        }
    
        context.SaveChanges();
    }

    private static void SeedMiniFactions(AppDbContext context)
    {
        if (context.MiniFactions.Any()) return;

        foreach (var factionData in InitialData.MiniFactions)
        {
            var miniFaction = new MiniFaction
            {
                FactionName = factionData.factionName,
                FactionDesc = factionData.factionDesc,
            };
            
            context.MiniFactions.Add(miniFaction);
        }
        
        context.SaveChanges();
    }

    private static void SeedMiniManufacturers(AppDbContext context)
    {
        if (context.MiniManufacturers.Any()) return;

        foreach (var manufacturerData in InitialData.MiniManufacturers)
        {
            var miniManufacturer = new MiniManufacturer()
            {
                ManufacturerName = manufacturerData.manufacturerName,
                HeadquartersLocation = manufacturerData.manuHQ,
                ContactEmail = manufacturerData.contactEmail,
                ContactPhone = manufacturerData.contactPhone
            };
            
            context.MiniManufacturers.Add(miniManufacturer);
        }
        
        context.SaveChanges();
    }
    
    private static void SeedMiniProperties(AppDbContext context)
    {
        if (context.MiniProperties.Any()) return;

        foreach (var propertiesData in InitialData.MiniProperties)
        {
            var miniProperties = new MiniProperties()
            {
                Id = propertiesData.id,
                PropertyName = propertiesData.propertyName,
                PropertyDesc = propertiesData.propertyDesc,
            };
            
            context.MiniProperties.Add(miniProperties);
        }
        
        context.SaveChanges();
    }

    // TODO: Solve FK constraint issue
    /*private static void SeedMiniatures(AppDbContext context)
    {
        if (context.Miniatures.Any()) return;
    
        foreach (var miniatureData in InitialData.Miniature)
        {
            var miniature = new Miniature
            {
                MiniName = miniatureData.miniName,
                MiniDesc = miniatureData.miniDesc,
                MiniFactionId = miniatureData.factionId,
                MiniManufacturerId = miniatureData.manuId,
                MiniPropertiesId = miniatureData.propertyId,
                
            };
        
            context.Miniatures.Add(miniature);
        }
    
        context.SaveChanges();
    }*/

}
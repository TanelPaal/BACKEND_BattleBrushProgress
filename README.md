# icd0024-24-25-s
**Student Name:** Tanel Paal

**Uni-ID:** tanpaa

**School e-mail:** tanpaa@taltech.ee

**Student Code:** 222775IADB

# Entity Framework Core
## EF Core Migrations
### Add Migration:
~~~sh
dotnet ef migrations add InitialCreate --project App.DAL.EF --startup-project WebApp --context AppDbContext
~~~
### Remove Migration:
~~~sh
dotnet ef migrations   --project App.DAL.EF --startup-project WebApp remove
~~~

### Create or Update:
~~~sh
dotnet ef database update --project WebApp --startup-project WebApp
~~~
### Drop:
~~~sh
dotnet ef database drop --project WebApp --startup-project WebApp --force
~~~

## MVC Controllers

Install from nuget:
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.EntityFrameworkCore.SqlServer

Run from WebApp folder

~~~sh
cd WebApp
~~~
~~~sh
dotnet aspnet-codegenerator controller -name PaintController -actions -m App.Domain.Paint -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name BrandController -actions -m App.Domain.Brand -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name MiniatureController -actions -m App.Domain.Miniature -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f


dotnet aspnet-codegenerator controller -name MiniatureCollectionController -actions -m App.Domain.MiniatureCollection -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name MiniFactionController -actions -m App.Domain.MiniFaction -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name MiniManufacturerController -actions -m App.Domain.MiniManufacturer -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f


dotnet aspnet-codegenerator controller -name MiniPropertiesController -actions -m App.Domain.MiniProperties -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name MiniStateController -actions -m App.Domain.MiniState -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name PaintLineController -actions -m App.Domain.PaintLine -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f


dotnet aspnet-codegenerator controller -name PaintTypeController -actions -m App.Domain.PaintType -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name MiniPaintSwatchController -actions -m App.Domain.MiniPaintSwatch -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name PersonController -actions -m App.Domain.Person -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f


dotnet aspnet-codegenerator controller -name PersonPaintsController -actions -m App.Domain.PersonPaints -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

~~~

API Controllers
~~~sh
cd WebApp
~~~
~~~sh
dotnet aspnet-codegenerator controller -name PaintController  -m  App.Domain.Paint        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name BrandController  -m  App.Domain.Brand        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name MiniatureController  -m  App.Domain.Miniature        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name MiniatureCollectionController  -m  App.Domain.MiniatureCollection        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name MiniFactionController  -m  App.Domain.MiniFaction        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name MiniManufacturerController  -m  App.Domain.MiniManufacturer        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name MiniPropertiesController  -m  App.Domain.MiniProperties        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name MiniStateController  -m  App.Domain.MiniState       -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name PaintLineController  -m  App.Domain.PaintLine        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name PaintTypeController  -m  App.Domain.PaintType        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name MiniPaintSwatchController  -m  App.Domain.MiniPaintSwatch        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name PersonController  -m  App.Domain.Person        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name PersonPaintsController  -m  App.Domain.PersonPaints        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

~~~

~~~sh

dotnet aspnet-codegenerator controller -name RefreshTokensController        -actions -m  App.Domain.Identity.AppRefreshToken        -dc AppDbContext -outDir Areas/Admin/Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UsersController        -actions -m  App.Domain.Identity.AppUser        -dc AppDbContext -outDir Areas/Admin/Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name RolesController        -actions -m  App.Domain.Identity.AppRole        -dc AppDbContext -outDir Areas/Admin/Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UserRolesController        -actions -m  App.Domain.Identity.AppUserRole        -dc AppDbContext -outDir Areas/Admin/Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name UserManagementController         -actions -m  App.Domain.Identity.AppUser        -dc AppDbContext -outDir Areas/Admin/Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

~~~~



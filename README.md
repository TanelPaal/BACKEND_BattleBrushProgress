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

using System.Globalization;
using App.DAL.Contracts;
using App.DAL.EF;
using App.DAL.EF.Repositories;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

Console.WriteLine(builder.Environment.EnvironmentName);

if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options
            .UseNpgsql(
                connectionString, 
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            )
    );
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options
            .UseNpgsql(
                connectionString, 
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            )
            .ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            // disable tracking, allow id based shared entity creation
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)

    );
}

// register all the repo interfaces and their implementations, use scoped lifetime
// scoped - get created once per web client request (same as dbcontext)

// MiniPaintSwatch
builder.Services.AddScoped<IMiniPaintSwatchRepository, MiniPaintSwatchRepository>();

// PersonPaints
builder.Services.AddScoped<IPersonPaintsRepository, PersonPaintsRepository>();

//MiniatureCollection
builder.Services.AddScoped<IMiniStateRepository, MiniStateRepository>();
builder.Services.AddScoped<IMiniatureCollectionRepository, MiniatureCollectionRepository>();

//Paint
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IPaintLineRepository, PaintLineRepository>();
builder.Services.AddScoped<IPaintTypeRepository, PaintTypeRepository>();
builder.Services.AddScoped<IPaintRepository, PaintRepository>();

//Miniature
builder.Services.AddScoped<IMiniPropertiesRepository, MiniPropertiesRepository>();
builder.Services.AddScoped<IMiniFactionRepository, MiniFactionRepository>();
builder.Services.AddScoped<IMiniManufacturerRepository, MiniManufacturerRepository>();
builder.Services.AddScoped<IMiniatureRepository, MiniatureRepository>();





builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<AppUser, AppRole>(o => 
        o.SignIn.RequireConfirmedAccount = false)
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<App.DAL.EF.AppDbContext>()
    .AddDefaultTokenProviders();

// builder.Services.AddDefaultIdentity<IdentityUser>(
//         options => options.SignIn.RequireConfirmedAccount = false)
//     .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IEmailSender, WebApp.Services.NoOpEmailSender>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// After your other service registrations
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

// add culture switching support
var supportedCultures = builder.Configuration
    .GetSection("SupportedCultures")
    .GetChildren()
    .Select(x => new CultureInfo(x.Value!))
    .ToArray();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // datetime and currency support
    options.SupportedCultures = supportedCultures;
    // UI translated strings
    options.SupportedUICultures = supportedCultures;
    // if nothing is found, use this
    options.DefaultRequestCulture =
        new RequestCulture(
            builder.Configuration["DefaultCulture"]!, 
            builder.Configuration["DefaultCulture"]!);
    options.SetDefaultCulture(builder.Configuration["DefaultCulture"]!);

    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        // Order is important, it's in which order they will be evaluated
        // add support for ?culture=ru-RU
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider()
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRequestLocalization(options: app.Services.GetService<IOptions<RequestLocalizationOptions>>()!.Value!);

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
    .WithStaticAssets();


app.Run();
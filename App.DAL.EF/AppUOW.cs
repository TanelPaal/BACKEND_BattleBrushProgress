using App.DAL.Contracts;
using App.DAL.EF.Repositories;
using Base.DAL.EF;

namespace App.DAL.EF;

public class AppUOW : BaseUOW<AppDbContext>, IAppUOW
{
    public AppUOW(AppDbContext uowDbContext) : base(uowDbContext)
    {
    }
    
    private BrandRepository? _brandRepository;
    public IBrandRepository BrandRepository =>
        _brandRepository ??= new BrandRepository(UOWDbContext);
    
    private IMiniatureCollectionRepository? _miniatureCollectionRepository;
    public IMiniatureCollectionRepository MiniatureCollectionRepository =>
        _miniatureCollectionRepository ??= new MiniatureCollectionRepository(UOWDbContext);
    
    private IMiniatureRepository? _miniatureRepository;
    public IMiniatureRepository MiniatureRepository =>
        _miniatureRepository ??= new MiniatureRepository(UOWDbContext);
    
    private IMiniFactionRepository? _miniFactionRepository;
    public IMiniFactionRepository MiniFactionRepository =>
        _miniFactionRepository ??= new MiniFactionRepository(UOWDbContext);
    
    private IMiniManufacturerRepository? _miniManufacturerRepository;
    public IMiniManufacturerRepository MiniManufacturerRepository =>
        _miniManufacturerRepository ??= new MiniManufacturerRepository(UOWDbContext);
    
    private IMiniPaintSwatchRepository? _miniPaintSwatchRepository;
    public IMiniPaintSwatchRepository MiniPaintSwatchRepository =>
        _miniPaintSwatchRepository ??= new MiniPaintSwatchRepository(UOWDbContext);
    
    private IMiniPropertiesRepository? _miniPropertiesRepository;
    public IMiniPropertiesRepository MiniPropertiesRepository =>
        _miniPropertiesRepository ??= new MiniPropertiesRepository(UOWDbContext);
    
    private IMiniStateRepository? _miniStateRepository;
    public IMiniStateRepository MiniStateRepository =>
        _miniStateRepository ??= new MiniStateRepository(UOWDbContext);
    
    private IPaintLineRepository? _paintLineRepository;
    public IPaintLineRepository PaintLineRepository =>
        _paintLineRepository ??= new PaintLineRepository(UOWDbContext);
    
    private IPaintRepository? _paintRepository;
    public IPaintRepository PaintRepository =>
        _paintRepository ??= new PaintRepository(UOWDbContext);
    
    private IPaintTypeRepository? _paintTypeRepository;
    public IPaintTypeRepository PaintTypeRepository =>
        _paintTypeRepository ??= new PaintTypeRepository(UOWDbContext);
    
    private IPersonPaintsRepository? _personPaintsRepository;
    public IPersonPaintsRepository PersonPaintsRepository =>
        _personPaintsRepository ??= new PersonPaintsRepository(UOWDbContext);
    
    private IPersonRepository? _personRepository;
    public IPersonRepository PersonRepository =>
        _personRepository ??= new PersonRepository(UOWDbContext);
}
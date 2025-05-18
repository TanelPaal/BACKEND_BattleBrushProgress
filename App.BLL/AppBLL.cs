using App.BLL.Contracts;
using App.BLL.Mappers;
using App.BLL.Services;
using App.DAL.Contracts;
using App.DAL.EF;
using Base.BLL;

namespace App.BLL;

public class AppBLL : BaseBLL<IAppUOW>, IAppBLL
{
    public AppBLL(IAppUOW uow) : base(uow)
    {
    }

    private IBrandService? _brandService;
    public IBrandService BrandService =>
        _brandService ??= new BrandService(
            BLLUOW,
            new BrandBLLMapper()
        );
    
    private IMiniatureCollectionService? _miniatureCollectionService;
    public IMiniatureCollectionService MiniatureCollectionService =>
        _miniatureCollectionService ??= new MiniatureCollectionService(
            BLLUOW,
            new MiniatureCollectionBLLMapper()
        );
    
    private IMiniatureService? _miniatureService;
    public IMiniatureService MiniatureService =>
        _miniatureService ??= new MiniatureService(
            BLLUOW,
            new MiniatureBLLMapper()
        );
    
    private IMiniFactionService? _niniFactionService;
    public IMiniFactionService MiniFactionService =>
        _niniFactionService ??= new MiniFactionService(
            BLLUOW,
            new MiniFactionBLLMapper()
        );
    
    private IMiniManufacturerService? _miniManufacturerService;
    public IMiniManufacturerService MiniManufacturerService =>
        _miniManufacturerService ??= new MiniManufacturerService(
            BLLUOW,
            new MiniManufacturerBLLMapper()
        );
    
    private IMiniPaintSwatchService? _miniPaintSwatchService;
    public IMiniPaintSwatchService MiniPaintSwatchService =>
        _miniPaintSwatchService ??= new MiniPaintSwatchService(
            BLLUOW,
            new MiniPaintSwatchBLLMapper()
        );
    
    private IMiniPropertiesService? _miniPropertiesService;
    public IMiniPropertiesService MiniPropertiesService =>
        _miniPropertiesService ??= new MiniPropertiesService(
            BLLUOW,
            new MiniPropertiesBLLMapper()
        );
    
    private IMiniStateService? _miniStateService;
    public IMiniStateService MiniStateService =>
        _miniStateService ??= new MiniStateService(
            BLLUOW,
            new MiniStateBLLMapper()
        );
    
    private IPaintLineService? _paintLineService;
    public IPaintLineService PaintLineService =>
        _paintLineService ??= new PaintLineService(
            BLLUOW,
            new PaintLineBLLMapper()
        );
    
    private IPaintService? _paintService;
    public IPaintService PaintService =>
        _paintService ??= new PaintService(
            BLLUOW,
            new PaintBLLMapper()
        );
    
    private IPaintTypeService? _paintTypeService;
    public IPaintTypeService PaintTypeService =>
        _paintTypeService ??= new PaintTypeService(
            BLLUOW,
            new PaintTypeBLLMapper()
        );
    
    private IPersonPaintsService? _personPaintsService;
    public IPersonPaintsService PersonPaintsService =>
        _personPaintsService ??= new PersonPaintsService(
            BLLUOW,
            new PersonPaintsBLLMapper()
        );
    
    private IPersonService? _personService;
    public IPersonService PersonService =>
        _personService ??= new PersonService(
            BLLUOW,
            new PersonBLLMapper()
            );
    
    public IMiniatureCollectionStatsService MiniatureCollectionStatsService { get; }

    public AppBLL(
        IAppUOW uow,
        IMiniatureCollectionRepository miniatureCollectionRepository,
        IMiniStateRepository miniStateRepository
    ) : base(uow)
    {
        MiniatureCollectionStatsService = new MiniatureCollectionStatsService(
            miniatureCollectionRepository, miniStateRepository
        );
    }
}
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IAppUOW : IBaseUOW
{
    IBrandRepository BrandRepository { get; }
    IMiniatureCollectionRepository MiniatureCollectionRepository { get; }
    IMiniatureRepository MiniatureRepository { get; }
    IMiniFactionRepository MiniFactionRepository { get; }
    IMiniManufacturerRepository MiniManufacturerRepository { get; }
    IMiniPaintSwatchRepository MiniPaintSwatchRepository { get; }
    IMiniPropertiesRepository MiniPropertiesRepository { get; }
    IMiniStateRepository MiniStateRepository { get; }
    IPaintLineRepository PaintLineRepository { get; }
    IPaintRepository PaintRepository { get; }
    IPaintTypeRepository PaintTypeRepository { get; }
    IPersonPaintsRepository PersonPaintsRepository { get; }
    IPersonRepository PersonRepository { get; }
    
}
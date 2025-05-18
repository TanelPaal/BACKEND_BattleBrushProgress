using Base.BLL.Contracts;

namespace App.BLL.Contracts;

public interface IAppBLL : IBaseBLL
{
    IBrandService BrandService { get; }
    IMiniatureCollectionService MiniatureCollectionService { get; }
    IMiniatureService MiniatureService { get; }
    IMiniFactionService MiniFactionService { get; }
    IMiniManufacturerService MiniManufacturerService { get; }
    IMiniPaintSwatchService MiniPaintSwatchService { get; }
    IMiniPropertiesService MiniPropertiesService { get; }
    IMiniStateService MiniStateService { get; }
    IPaintLineService PaintLineService { get; }
    IPaintService PaintService { get; }
    IPaintTypeService PaintTypeService { get; }
    IPersonPaintsService PersonPaintsService { get; }
    IPersonService PersonService { get; }
    IMiniatureCollectionStatsService MiniatureCollectionStatsService { get; }
    IPersonPaintsStatsService PersonPaintsStatsService { get; }
    IRandomMiniaturePickerService RandomMiniaturePickerService { get; }
}
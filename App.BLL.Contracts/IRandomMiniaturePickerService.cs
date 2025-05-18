using App.DTO.v1;

namespace App.BLL.Contracts;

public interface IRandomMiniaturePickerService
{
    Task<RandomMiniaturePick?> GetRandomMiniatureToPaint(Guid userId);
}
using App.BLL.Contracts;
using App.DAL.Contracts;
using App.DTO.v1;

namespace App.BLL.Services;

public class RandomMiniaturePickerService : IRandomMiniaturePickerService
{
    private readonly IAppUOW _uow;

    public RandomMiniaturePickerService(IAppUOW uow)
    {
        _uow = uow;
    }

    public async Task<RandomMiniaturePick?> GetRandomMiniatureToPaint(Guid userId)
    {
        var collections = await _uow.MiniatureCollectionRepository.AllAsync(userId);
        var collectionList = collections.ToList();
        if (!collectionList.Any()) return null;

        var random = new Random();
        var pick = collectionList[random.Next(collectionList.Count)];

        return new RandomMiniaturePick
        {
            MiniatureCollectionId = pick.Id,
            CollectionName = pick.CollectionName,
            CollectionDesc = pick.CollectionDesc
        };
    }
}
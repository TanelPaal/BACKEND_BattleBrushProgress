using App.BLL.Services;
using App.DAL.Contracts;
using Base.Contracts;
using Moq;

namespace App.Test.Unit;

public class PersonPaintsServiceTests
{
    private readonly PersonPaintsService _personPaintsService;
    private readonly Mock<IPersonPaintsRepository> _personPaintsRepoMock = new();
    private readonly Mock<IMapper<App.BLL.DTO.PersonPaints, App.DAL.DTO.PersonPaints>> _mapperMock = new();

    public PersonPaintsServiceTests()
    {
        var uowMock = new Mock<IAppUOW>();
        uowMock.Setup(u => u.PersonPaintsRepository).Returns(_personPaintsRepoMock.Object);

        _personPaintsService = new PersonPaintsService(uowMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task AllAsync_ReturnsMappedPersonPaintsList()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var dalList = new List<App.DAL.DTO.PersonPaints> 
        { 
            new() { Id = Guid.NewGuid(), Quantity = 2 },
            new() { Id = Guid.NewGuid(), Quantity = 3 }
        };
        var bllList = dalList.Select(d => new App.BLL.DTO.PersonPaints { Id = d.Id, Quantity = d.Quantity }).ToList();

        _personPaintsRepoMock.Setup(r => r.AllAsync(userId)).ReturnsAsync(dalList);
        _mapperMock.Setup(m => m.Map(It.IsAny<App.DAL.DTO.PersonPaints>()))
            .Returns((App.DAL.DTO.PersonPaints d) => bllList.First(b => b.Id == d.Id));

        // Act
        var result = await _personPaintsService.AllAsync(userId);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.All(result, r => Assert.Contains(bllList, b => b.Id == r.Id && b.Quantity == r.Quantity));
    }

    [Fact]
    public async Task FindAsync_ReturnsMappedPersonPaints()
    {
        // Arrange
        var id = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var dalPersonPaints = new App.DAL.DTO.PersonPaints { Id = id, Quantity = 5 };
        var bllPersonPaints = new App.BLL.DTO.PersonPaints { Id = id, Quantity = 5 };

        _personPaintsRepoMock.Setup(r => r.FindAsync(id, userId)).ReturnsAsync(dalPersonPaints);
        _mapperMock.Setup(m => m.Map(dalPersonPaints)).Returns(bllPersonPaints);

        // Act
        var result = await _personPaintsService.FindAsync(id, userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result!.Id);
        Assert.Equal(5, result.Quantity);
    }

    [Fact]
    public async Task Add_MapsAndCallsRepo()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var bllPersonPaints = new App.BLL.DTO.PersonPaints { Id = Guid.NewGuid(), Quantity = 10 };
        var dalPersonPaints = new App.DAL.DTO.PersonPaints { Id = bllPersonPaints.Id, Quantity = 10 };

        _mapperMock.Setup(m => m.Map(bllPersonPaints)).Returns(dalPersonPaints);

        // Act
        _personPaintsService.Add(bllPersonPaints, userId);

        // Assert
        _personPaintsRepoMock.Verify(r => r.Add(dalPersonPaints, userId), Times.Once);
    }

    [Fact]
    public async Task Update_MapsAndCallsRepo()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var bllPersonPaints = new App.BLL.DTO.PersonPaints { Id = Guid.NewGuid(), Quantity = 15 };
        var dalPersonPaints = new App.DAL.DTO.PersonPaints { Id = bllPersonPaints.Id, Quantity = 15 };

        _mapperMock.Setup(m => m.Map(bllPersonPaints)).Returns(dalPersonPaints);

        // Act
        _personPaintsService.Update(bllPersonPaints, userId);

        // Assert
        _personPaintsRepoMock.Verify(r => r.Update(dalPersonPaints, userId), Times.Once);
    }

    [Fact]
    public async Task RemoveAsync_CallsRepo()
    {
        // Arrange
        var id = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var dalPersonPaints = new App.DAL.DTO.PersonPaints { Id = id };

        _personPaintsRepoMock.Setup(r => r.FindAsync(id, userId)).ReturnsAsync(dalPersonPaints);

        // Act
        await _personPaintsService.RemoveAsync(id, userId);

        // Assert
        _personPaintsRepoMock.Verify(r => r.RemoveAsync(id, userId), Times.Once);
    }

    [Fact]
    public async Task ExistsAsync_ReturnsCorrect()
    {
        // Arrange
        var id = Guid.NewGuid();
        var userId = Guid.NewGuid();
        _personPaintsRepoMock.Setup(r => r.FindAsync(id, userId))
            .ReturnsAsync(new App.DAL.DTO.PersonPaints { Id = id });

        // Act
        var exists = await _personPaintsService.ExistsAsync(id, userId);

        // Assert
        Assert.True(exists);
    }
} 
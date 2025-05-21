using Base.BLL;
using Base.BLL.Contracts;
using Base.Contracts;
using Base.DAL.Contracts;
using Moq;
using Xunit;

namespace App.Test.Unit;

// Dummy entities for testing
public class DummyBllEntity : IDomainId
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
}

public class DummyDalEntity : IDomainId
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
}

public class BaseServiceTests
{
    private readonly BaseService<DummyBllEntity, DummyDalEntity, IBaseRepository<DummyDalEntity>> _baseService;
    private readonly Mock<IBaseRepository<DummyDalEntity>> _repoMock = new();
    private readonly Mock<IMapper<DummyBllEntity, DummyDalEntity>> _mapperMock = new();

    public BaseServiceTests()
    {
        var uowMock = new Mock<IBaseUOW>();
        _baseService = new BaseService<DummyBllEntity, DummyDalEntity, IBaseRepository<DummyDalEntity>>(
            uowMock.Object,
            _repoMock.Object,
            _mapperMock.Object
        );
    }

    [Fact]
    public void All_ReturnsMappedEntities()
    {
        // Arrange
        var dalList = new List<DummyDalEntity> 
        { 
            new() { Id = Guid.NewGuid(), Name = "Test1" },
            new() { Id = Guid.NewGuid(), Name = "Test2" }
        };
        var bllList = dalList.Select(d => new DummyBllEntity { Id = d.Id, Name = d.Name }).ToList();

        _repoMock.Setup<IEnumerable<DummyDalEntity>>(r => r.All(It.IsAny<Guid>())).Returns(dalList);
        _mapperMock.Setup(m => m.Map(It.IsAny<DummyDalEntity>()))
            .Returns((DummyDalEntity d) => bllList.First(b => b.Id == d.Id));

        // Act
        var result = _baseService.All().ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.All(result, r => Assert.Contains(bllList, b => b.Id == r.Id && b.Name == r.Name));
    }

    [Fact]
    public async Task AllAsync_ReturnsMappedEntities()
    {
        // Arrange
        var dalList = new List<DummyDalEntity> 
        { 
            new() { Id = Guid.NewGuid(), Name = "Test1" },
            new() { Id = Guid.NewGuid(), Name = "Test2" }
        };
        var bllList = dalList.Select(d => new DummyBllEntity { Id = d.Id, Name = d.Name }).ToList();

        _repoMock.Setup<Task<IEnumerable<DummyDalEntity>>>(r => r.AllAsync(It.IsAny<Guid>())).ReturnsAsync(dalList);
        _mapperMock.Setup(m => m.Map(It.IsAny<DummyDalEntity>()))
            .Returns((DummyDalEntity d) => bllList.First(b => b.Id == d.Id));

        // Act
        var result = (await _baseService.AllAsync()).ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.All(result, r => Assert.Contains(bllList, b => b.Id == r.Id && b.Name == r.Name));
    }

    [Fact]
    public void Find_ReturnsMappedEntity()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dalEntity = new DummyDalEntity { Id = id, Name = "Test" };
        var bllEntity = new DummyBllEntity { Id = id, Name = "Test" };

        _repoMock.Setup<DummyDalEntity?>(r => r.Find(id, It.IsAny<Guid>())).Returns(dalEntity);
        _mapperMock.Setup(m => m.Map(dalEntity)).Returns(bllEntity);

        // Act
        var result = _baseService.Find(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result!.Id);
        Assert.Equal("Test", result.Name);
    }

    [Fact]
    public async Task FindAsync_ReturnsMappedEntity()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dalEntity = new DummyDalEntity { Id = id, Name = "Test" };
        var bllEntity = new DummyBllEntity { Id = id, Name = "Test" };

        _repoMock.Setup<Task<DummyDalEntity?>>(r => r.FindAsync(id, It.IsAny<Guid>())).ReturnsAsync(dalEntity);
        _mapperMock.Setup(m => m.Map(dalEntity)).Returns(bllEntity);

        // Act
        var result = await _baseService.FindAsync(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result!.Id);
        Assert.Equal("Test", result.Name);
    }

    [Fact]
    public void Add_MapsAndCallsRepo()
    {
        // Arrange
        var bllEntity = new DummyBllEntity { Id = Guid.NewGuid(), Name = "Test" };
        var dalEntity = new DummyDalEntity { Id = bllEntity.Id, Name = bllEntity.Name };

        _mapperMock.Setup(m => m.Map(bllEntity)).Returns(dalEntity);

        // Act
        _baseService.Add(bllEntity);

        // Assert
        _repoMock.Verify(r => r.Add(dalEntity, It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public void Update_MapsAndCallsRepo()
    {
        // Arrange
        var bllEntity = new DummyBllEntity { Id = Guid.NewGuid(), Name = "Test" };
        var dalEntity = new DummyDalEntity { Id = bllEntity.Id, Name = bllEntity.Name };

        _mapperMock.Setup(m => m.Map(bllEntity)).Returns(dalEntity);
        _repoMock.Setup<DummyDalEntity?>(r => r.Update(dalEntity, It.IsAny<Guid>())).Returns(dalEntity);
        _mapperMock.Setup(m => m.Map(dalEntity)).Returns(bllEntity);

        // Act
        var result = _baseService.Update(bllEntity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bllEntity.Id, result!.Id);
        Assert.Equal(bllEntity.Name, result.Name);
    }

    [Fact]
    public async Task UpdateAsync_MapsAndCallsRepo()
    {
        // Arrange
        var bllEntity = new DummyBllEntity { Id = Guid.NewGuid(), Name = "Test" };
        var dalEntity = new DummyDalEntity { Id = bllEntity.Id, Name = bllEntity.Name };

        _mapperMock.Setup(m => m.Map(bllEntity)).Returns(dalEntity);
        _repoMock.Setup<Task<DummyDalEntity?>>(r => r.UpdateAsync(dalEntity, It.IsAny<Guid>())).ReturnsAsync(dalEntity);
        _mapperMock.Setup(m => m.Map(dalEntity)).Returns(bllEntity);

        // Act
        var result = await _baseService.UpdateAsync(bllEntity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bllEntity.Id, result!.Id);
        Assert.Equal(bllEntity.Name, result.Name);
    }

    [Fact]
    public void Remove_ByEntity_CallsRepo()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dalEntity = new DummyDalEntity { Id = id };

        _repoMock.Setup<DummyDalEntity?>(r => r.Find(id, It.IsAny<Guid>())).Returns(dalEntity);

        // Act
        _baseService.Remove(new DummyBllEntity { Id = id });

        // Assert
        _repoMock.Verify(r => r.Remove(dalEntity, It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public void Remove_ById_CallsRepo()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dalEntity = new DummyDalEntity { Id = id };

        _repoMock.Setup<DummyDalEntity?>(r => r.Find(id, It.IsAny<Guid>())).Returns(dalEntity);

        // Act
        _baseService.Remove(id);

        // Assert
        _repoMock.Verify(r => r.Remove(dalEntity, It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public async Task RemoveAsync_CallsRepo()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dalEntity = new DummyDalEntity { Id = id };

        _repoMock.Setup<Task<DummyDalEntity?>>(r => r.FindAsync(id, It.IsAny<Guid>())).ReturnsAsync(dalEntity);

        // Act
        await _baseService.RemoveAsync(id);

        // Assert
        _repoMock.Verify(r => r.RemoveAsync(id, It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public void Exists_ReturnsCorrect()
    {
        // Arrange
        var id = Guid.NewGuid();
        _repoMock.Setup<DummyDalEntity?>(r => r.Find(id, It.IsAny<Guid>())).Returns(new DummyDalEntity { Id = id });

        // Act
        var exists = _baseService.Exists(id);

        // Assert
        Assert.True(exists);
    }

    [Fact]
    public async Task ExistsAsync_ReturnsCorrect()
    {
        // Arrange
        var id = Guid.NewGuid();
        _repoMock.Setup<Task<DummyDalEntity?>>(r => r.FindAsync(id, It.IsAny<Guid>())).ReturnsAsync(new DummyDalEntity { Id = id });

        // Act
        var exists = await _baseService.ExistsAsync(id);

        // Assert
        Assert.True(exists);
    }
}
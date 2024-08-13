using Moq;
using Xunit;

// MotoServiceTests.cs
public class MotoServiceTests
{
    private readonly Mock<IMotoRepository> _motoRepositoryMock;
    private readonly Mock<INotificationService> _notificationServiceMock;
    private readonly MotoService _motoService;

    public MotoServiceTests()
    {
        _motoRepositoryMock = new Mock<IMotoRepository>();
        _notificationServiceMock = new Mock<INotificationService>();
        _motoService = new MotoService(_motoRepositoryMock.Object, _notificationServiceMock.Object);
    }

    [Fact]
    public async Task AddMotoAsync_ShouldAddMoto_WhenValid()
    {
        // Arrange
        var motoDto = new MotoDTO
        {
            Identificador = "12345",
            Ano = 2024,
            Modelo = "Model X",
            Placa = "ABC-1234"
        };

        // Act
        var result = await _motoService.AddMotoAsync(motoDto);

        // Assert
        _motoRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Moto>()), Times.Once);
        _notificationServiceMock.Verify(x => x.NotifyMotoCreatedAsync(It.IsAny<Moto>()), Times.Once);
        
    }

    // Add more tests here if needed
}
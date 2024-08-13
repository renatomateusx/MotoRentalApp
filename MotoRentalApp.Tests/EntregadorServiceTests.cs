using Moq;
using Xunit;

public class EntregadorServiceTests
{
    private readonly Mock<IEntregadorRepository> _entregadorRepositoryMock;
    private readonly EntregadorService _entregadorService;

    public EntregadorServiceTests()
    {
        _entregadorRepositoryMock = new Mock<IEntregadorRepository>();
        _entregadorService = new EntregadorService(_entregadorRepositoryMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsEntregador()
    {
        // Arrange
        var id = 1;
        var entregador = new Entregador { Id = id, Nome = "John Doe" };
        _entregadorRepositoryMock.Setup(repo => repo.GetByIdAsync(id))
            .ReturnsAsync(entregador);

        // Act
        var result = await _entregadorService.GetByIdAsync(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, 1);
    }

    [Fact]
    public async Task AddAsync_AddsEntregador_WhenValid()
    {
        // Arrange
        var entregador = new Entregador { Id = 1, Cnpj = "12345678000195", NumeroCNH = "12345678900" };

        _entregadorRepositoryMock.Setup(repo => repo.GetByCnpjAsync(entregador.Cnpj))
            .ReturnsAsync((Entregador)null);
        _entregadorRepositoryMock.Setup(repo => repo.GetByNumeroCNHAsync(entregador.NumeroCNH))
            .ReturnsAsync((Entregador)null);

        // Act
        await _entregadorService.AddAsync(entregador);

        // Assert
        _entregadorRepositoryMock.Verify(repo => repo.AddAsync(entregador), Times.Once);
    }

    [Fact]
    public async Task AddAsync_ThrowsException_WhenCnpjAlreadyExists()
    {
        // Arrange
        var entregador = new Entregador { Id = 1, Cnpj = "12345678000195" };
        _entregadorRepositoryMock.Setup(repo => repo.GetByCnpjAsync(entregador.Cnpj))
            .ReturnsAsync(new Entregador());

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _entregadorService.AddAsync(entregador));
    }

    // Add more tests at your convenience
}
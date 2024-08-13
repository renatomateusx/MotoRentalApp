using Moq;
using Xunit;

public class LocacaoServiceTests
{
    private readonly Mock<ILocacaoRepository> _mockLocacaoRepository;
    private readonly Mock<IEntregadorRepository> _mockEntregadorRepository;
    private readonly Mock<IMotoRepository> _mockMotoRepository;
    private readonly LocacaoService _locacaoService;

    public LocacaoServiceTests()
    {
        _mockLocacaoRepository = new Mock<ILocacaoRepository>();
        _mockEntregadorRepository = new Mock<IEntregadorRepository>();
        _mockMotoRepository = new Mock<IMotoRepository>();
        _locacaoService = new LocacaoService(_mockLocacaoRepository.Object, _mockEntregadorRepository.Object, _mockMotoRepository.Object);
    }

    [Fact]
    public async Task AddLocacaoAsync_ShouldThrowException_WhenEntregadorNotEnabled()
    {
        // Arrange
        var locacao = new Locacao { EntregadorId = 1 };
        _mockEntregadorRepository.Setup(r => r.GetByIdAsync(locacao.EntregadorId)).ReturnsAsync(new Entregador { TipoCNH = "B" });

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _locacaoService.AddLocacaoAsync(locacao));
    }

    // Outros testes
}

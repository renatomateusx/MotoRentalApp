using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

public class LocacaoService
{
    private readonly ILocacaoRepository _locacaoRepository;
    private readonly IEntregadorRepository _entregadorRepository;
    private readonly IMotoRepository _motoRepository;

    public LocacaoService(ILocacaoRepository locacaoRepository, IEntregadorRepository entregadorRepository, IMotoRepository motoRepository)
    {
        _locacaoRepository = locacaoRepository;
        _entregadorRepository = entregadorRepository;
        _motoRepository = motoRepository;
    }

    public async Task<Locacao> GetByIdAsync(int id)
    {
        return await _locacaoRepository.GetByIdAsync(id);
    }

    public async Task AddLocacaoAsync(Locacao locacao)
        {
            var entregador = await _entregadorRepository.GetByIdAsync(locacao.EntregadorId);
            if (entregador == null || entregador.TipoCNH != "A")
            {
                throw new Exception("Entregador não habilitado para locação.");
            }

            var moto = await _motoRepository.GetByIdAsync(locacao.MotoId);
            if (moto == null)
            {
                throw new Exception("Moto não encontrada.");
            }

            await _locacaoRepository.AddAsync(locacao);
        }

        public decimal CalcularValorTotal(Locacao locacao)
        {
            // Lógica para calcular valor com base nas regras fornecidas
            return 0m;
        }
}
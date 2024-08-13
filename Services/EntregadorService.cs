using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

public class EntregadorService
{
    private readonly IEntregadorRepository _entregadorRepository;

    public EntregadorService(IEntregadorRepository entregadorRepository)
    {
        _entregadorRepository = entregadorRepository;
    }

    public async Task<Entregador> GetByIdAsync(int id)
    {
        return await _entregadorRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Entregador entregador)
    {
        // Validações e lógica de negócios
        var existingEntregadorByCnpj = await _entregadorRepository.GetByCnpjAsync(entregador.Cnpj);
        if (existingEntregadorByCnpj != null)
        {
            throw new Exception("CNPJ already exists");
        }

        var existingEntregadorByNumeroCNH = await _entregadorRepository.GetByNumeroCNHAsync(entregador.NumeroCNH);
        if (existingEntregadorByNumeroCNH != null)
        {
            throw new Exception("CNH number already exists");
        }

        await _entregadorRepository.AddAsync(entregador);
    }

    public async Task UpdateAsync(Entregador entregador)
    {
        // Validações e lógica de negócios
        var existingEntregador = await _entregadorRepository.GetByIdAsync(entregador.Id);
        if (existingEntregador == null)
        {
            throw new Exception("Entregador not found");
        }

        var existingEntregadorByCnpj = await _entregadorRepository.GetByCnpjAsync(entregador.Cnpj);
        if (existingEntregadorByCnpj != null && existingEntregadorByCnpj.Id != entregador.Id)
        {
            throw new Exception("CNPJ already exists");
        }

        var existingEntregadorByNumeroCNH = await _entregadorRepository.GetByNumeroCNHAsync(entregador.NumeroCNH);
        if (existingEntregadorByNumeroCNH != null && existingEntregadorByNumeroCNH.Id != entregador.Id)
        {
            throw new Exception("CNH number already exists");
        }

        await _entregadorRepository.UpdateAsync(entregador);
    }

    public async Task DeleteAsync(int id)
    {
        var entregador = await _entregadorRepository.GetByIdAsync(id);
        if (entregador == null)
        {
            throw new Exception("Entregador not found");
        }

        await _entregadorRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Entregador>> GetAllAsync()
    {
        return await _entregadorRepository.GetAllAsync();
    }
}
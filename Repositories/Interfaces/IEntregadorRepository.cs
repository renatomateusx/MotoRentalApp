
public interface IEntregadorRepository
{
    Task<Entregador> GetByIdAsync(int id);
    Task AddAsync(Entregador entregador);
    Task UpdateAsync(Entregador entregador);
    Task DeleteAsync(int id);
    Task<IEnumerable<Entregador>> GetAllAsync();
    Task<Entregador> GetByCnpjAsync(string cnpj);
    Task<Entregador> GetByNumeroCNHAsync(string numeroCNH);
}
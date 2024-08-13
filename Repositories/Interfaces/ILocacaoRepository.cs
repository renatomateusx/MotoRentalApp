public interface ILocacaoRepository
{
    Task<Locacao> GetByIdAsync(int id);
    Task AddAsync(Locacao locacao);
    Task UpdateAsync(Locacao locacao);
    Task DeleteAsync(int id);
    Task<IEnumerable<Locacao>> GetAllAsync();
}
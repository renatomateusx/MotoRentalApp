
using Microsoft.EntityFrameworkCore;

public class LocacaoRepository : ILocacaoRepository
{
    private readonly MotoRentalContext _context;

    public LocacaoRepository(MotoRentalContext context)
    {
        _context = context;
    }

    public async Task<Locacao> GetByIdAsync(int id)
    {
        return await _context.Locacoes.FindAsync(id);
    }

    public async Task AddAsync(Locacao locacao)
    {
        await _context.Locacoes.AddAsync(locacao);
    }

    public async Task UpdateAsync(Locacao locacao)
    {
        _context.Locacoes.Update(locacao);
    }

    public async Task DeleteAsync(int id)
    {
        var locacao = await _context.Locacoes.FindAsync(id);
        if (locacao != null)
        {
            _context.Locacoes.Remove(locacao);
        }
    }

    public async Task<IEnumerable<Locacao>> GetAllAsync()
    {
        return await _context.Locacoes.ToListAsync();
    }
}

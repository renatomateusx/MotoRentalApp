using Microsoft.EntityFrameworkCore;

public class EntregadorRepository : IEntregadorRepository
{
    private readonly MotoRentalContext _context;

    public EntregadorRepository(MotoRentalContext context)
    {
        _context = context;
    }

    public async Task<Entregador> GetByIdAsync(int id)
    {
        return await _context.Entregadores.FindAsync(id);
    }

    public async Task AddAsync(Entregador entregador)
    {
        await _context.Entregadores.AddAsync(entregador);
    }

    public async Task UpdateAsync(Entregador entregador)
    {
        _context.Entregadores.Update(entregador);
    }

    public async Task DeleteAsync(int id)
    {
        var entregador = await _context.Entregadores.FindAsync(id);
        if (entregador != null)
        {
            _context.Entregadores.Remove(entregador);
        }
    }

    public async Task<IEnumerable<Entregador>> GetAllAsync()
    {
        return await _context.Entregadores.ToListAsync();
    }

    public async Task<Entregador> GetByCnpjAsync(string cnpj)
    {
        return await _context.Entregadores.SingleOrDefaultAsync(e => e.Cnpj == cnpj);
    }

    public async Task<Entregador> GetByNumeroCNHAsync(string numeroCNH)
    {
        return await _context.Entregadores.SingleOrDefaultAsync(e => e.NumeroCNH == numeroCNH);
    }
}
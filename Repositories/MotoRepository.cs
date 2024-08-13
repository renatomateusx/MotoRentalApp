
// MotoRepository.cs
using Microsoft.EntityFrameworkCore;

public class MotoRepository : IMotoRepository
{
    private readonly MotoRentalContext _context;

    public MotoRepository(MotoRentalContext context)
    {
        _context = context;
    }

    public async Task<Moto> GetByIdAsync(int id) => await _context.Motos.FindAsync(id);

    public async Task<Moto> GetByPlacaAsync(string placa) => 
        await _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);

    public async Task AddAsync(Moto moto)
    {
        await _context.Motos.AddAsync(moto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Moto moto)
    {
        _context.Motos.Update(moto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var moto = await GetByIdAsync(id);
        if (moto != null)
        {
            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
        }
    }
}
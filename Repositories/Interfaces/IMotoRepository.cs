// IMotoRepository.cs
using Microsoft.EntityFrameworkCore;

public interface IMotoRepository
{
    Task<Moto> GetByIdAsync(int id);
    Task<Moto> GetByPlacaAsync(string placa);
    Task AddAsync(Moto moto);
    Task UpdateAsync(Moto moto);
    Task DeleteAsync(int id);
}
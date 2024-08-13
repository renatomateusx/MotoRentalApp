// MotoService.cs
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

public class MotoService
{
    private readonly IMotoRepository _motoRepository;
    private readonly INotificationService _notificationService;

    public MotoService(IMotoRepository motoRepository, INotificationService notificationService)
    {
        _motoRepository = motoRepository;
        _notificationService = notificationService;
    }

    public async Task<MotoDTO> AddMotoAsync(MotoDTO motoDto)
    {
        var moto = new Moto
        {
            Identificador = motoDto.Identificador,
            Ano = motoDto.Ano,
            Modelo = motoDto.Modelo,
            Placa = motoDto.Placa
        };

        await _motoRepository.AddAsync(moto);
        await _notificationService.NotifyMotoCreatedAsync(moto);

        return motoDto;
    }

    public async Task<Moto> GetByIdAsync(int id)
    {
        return await _motoRepository.GetByIdAsync(id);
    }

    // Métodos para Update, Delete e Get
}
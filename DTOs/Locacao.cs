// LocacaoDTO.cs
public class LocacaoDTO
{
    public int EntregadorId { get; set; }
    public int MotoId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public DateTime DataPrevistaTermino { get; set; }
    public decimal ValorTotal { get; set; }
}
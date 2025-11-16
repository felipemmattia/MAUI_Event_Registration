namespace ProjetoEventos.Models;

public class Evento
{
    public string NomeEvento { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public int NumeroParticipantes { get; set; }
    public string LocalEvento { get; set; }
    public decimal CustoPorParticipante { get; set; }

    public int DuracaoEmDias => (DataFim - DataInicio).Days;
    public decimal CustoTotal => NumeroParticipantes * CustoPorParticipante;
}

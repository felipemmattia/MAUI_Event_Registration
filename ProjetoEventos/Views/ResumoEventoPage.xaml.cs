using ProjetoEventos.Models;

namespace ProjetoEventos.Views;

[QueryProperty(nameof(Dados), "dados")]
public partial class ResumoEventoPage : ContentPage
{
    private string _dados;
    public string Dados
    {
        get => _dados;
        set
        {
            _dados = Uri.UnescapeDataString(value);

            var evento = System.Text.Json.JsonSerializer.Deserialize<Evento>(_dados);

            BindingContext = new { Evento = evento };
        }
    }

    public ResumoEventoPage()
    {
        InitializeComponent();
    }
}

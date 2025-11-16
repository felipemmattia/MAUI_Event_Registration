using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ProjetoEventos.Models;

namespace ProjetoEventos.ViewModels;

public class CadastroEventoViewModel : INotifyPropertyChanged
{
    private Evento _evento = new Evento();

    public Evento Evento
    {
        get => _evento;
        set
        {
            _evento = value;
            OnPropertyChanged();
        }
    }

    // ============================
    // PARTICIPANTES (STEPER)
    // ============================
    private int _numeroParticipantes;
    public int NumeroParticipantes
    {
        get => _numeroParticipantes;
        set
        {
            if (_numeroParticipantes != value)
            {
                _numeroParticipantes = value;

                // mantém o Model atualizado
                Evento.NumeroParticipantes = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Evento));
            }
        }
    }

    // ============================
    // PREÇO POR PARTICIPANTE (Entry)
    // ============================
    private string _custoTexto;
    public string CustoTexto
    {
        get => _custoTexto;
        set
        {
            if (_custoTexto != value)
            {
                _custoTexto = value;

                // tenta converter o texto digitado
                if (decimal.TryParse(value, out decimal preco))
                    Evento.CustoPorParticipante = preco;
                else
                    Evento.CustoPorParticipante = 0;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Evento));
            }
        }
    }

    // ============================
    // COMMAND
    // ============================
    public ICommand CadastrarCommand { get; }

    public CadastroEventoViewModel()
    {
        // datas padrão
        Evento.DataInicio = DateTime.Now;
        Evento.DataFim = DateTime.Now.AddDays(1);

        // inicia contador
        NumeroParticipantes = Evento.NumeroParticipantes;

        // inicia texto do preço
        CustoTexto = ""; // garante placeholder ativo

        CadastrarCommand = new Command(async () =>
        {
            if (Evento.DataFim < Evento.DataInicio)
            {
                await Shell.Current.DisplayAlert("Erro", "A data final não pode ser menor que a inicial.", "OK");
                return;
            }

            var json = System.Text.Json.JsonSerializer.Serialize(Evento);

            await Shell.Current.GoToAsync($"resumo?dados={Uri.EscapeDataString(json)}");
        });
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

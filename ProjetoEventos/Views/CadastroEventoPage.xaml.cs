using ProjetoEventos.ViewModels;

namespace ProjetoEventos.Views;

public partial class CadastroEventoPage : ContentPage
{
    public CadastroEventoPage()
    {
        InitializeComponent();
        BindingContext = new CadastroEventoViewModel();
    }
}

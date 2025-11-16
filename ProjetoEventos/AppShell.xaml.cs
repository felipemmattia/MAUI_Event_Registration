using ProjetoEventos.Views;

namespace ProjetoEventos;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("resumo", typeof(ResumoEventoPage));
    }
}

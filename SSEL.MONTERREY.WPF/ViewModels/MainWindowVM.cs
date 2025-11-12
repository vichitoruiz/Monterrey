using System.Windows.Controls;
using System.Windows.Input;
using SSEL.MONTERREY.WPF.Helpers;
using SSEL.MONTERREY.WPF.Views;

namespace SSEL.MONTERREY.WPF.ViewModels;

public class MainWindowVM : ViewModelBase
{
    private UserControl _currentView;

    public UserControl CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }

    // 🔘 Comandos de navegación
    public ICommand NavigateDashboard { get; }
    public ICommand NavigateLecturas { get; }
    public ICommand NavigateReclamos { get; }
    public ICommand NavigateUsuarios { get; }
    public ICommand NavigateConfiguracion { get; }
    public ICommand NavigateAcercaDe { get; }

    public MainWindowVM()
    {
        // ✅ Carga vista inicial
        _currentView = new DashboardView();

        // ✅ Asigna comandos con lambdas
        NavigateDashboard = new RelayCommand(_ => CurrentView = new DashboardView());
        NavigateLecturas = new RelayCommand(_ => CurrentView = new LecturasView());
        NavigateReclamos = new RelayCommand(_ => CurrentView = new ReclamosView());
        NavigateUsuarios = new RelayCommand(_ => CurrentView = new UsuariosView());
        NavigateConfiguracion = new RelayCommand(_ => CurrentView = new ConfiguracionView());
        NavigateAcercaDe = new RelayCommand(_ => CurrentView = new AcercaDeView());
    }
}

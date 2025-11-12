using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSEL.MONTERREY.WPF.ViewModels;

public class DashboardVM : ViewModelBase
{
    private string _titulo = "Panel de Control - Dashboard";
    public string Titulo
    {
        get => _titulo;
        set { _titulo = value; SetProperty(); }
    }


}

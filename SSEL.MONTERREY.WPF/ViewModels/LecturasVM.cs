using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSEL.MONTERREY.WPF.ViewModels;

public class LecturasVM : ViewModelBase
{
    private string _titulo = "Lecturas View";
    public string Titulo
    {
        get => _titulo;
        set { _titulo = value; SetProperty(); }
    }

}

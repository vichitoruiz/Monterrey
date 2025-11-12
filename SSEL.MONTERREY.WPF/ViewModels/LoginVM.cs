using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSEL.MONTERREY.WPF.ViewModels;

public class LoginVM : ViewModelBase
{
    private string _titulo = "Login View";
    private string _usuario = string.Empty;
    private string _password = string.Empty;

    public string Titulo
    {
        get => _titulo;
        set
        {
            if (_titulo != value)
            {
                _titulo = value;
                OnPropertyChanged();
            }
        }
    }

    public string Usuario
    {
        get => _usuario;
        set
        {
            if (_usuario != value)
            {
                _usuario = value;
                OnPropertyChanged();
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                SetProperty();
            }
        }
    }


}


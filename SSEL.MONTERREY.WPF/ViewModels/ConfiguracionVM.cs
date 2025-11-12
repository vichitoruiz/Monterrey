using SSEL.MONTERREY.WPF.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SSEL.MONTERREY.WPF.ViewModels;

public class ConfiguracionVM : ViewModelBase
{
    private string _nombreSistema = "SSEL Monterrey";
    private string _rutaArchivos = "C:\\Datos";

    public string NombreSistema
    {
        get => _nombreSistema;
        set
        {
            if (_nombreSistema != value)
            {
                _nombreSistema = value;
                SetProperty();
            }
        }
    }

    public string RutaArchivos
    {
        get => _rutaArchivos;
        set
        {
            if (_rutaArchivos != value)
            {
                _rutaArchivos = value;
                SetProperty();
            }
        }
    }

    public ICommand GuardarCommand { get; }

    public ConfiguracionVM()
    {
        GuardarCommand = new RelayCommand(_ => Guardar());
    }

    private void Guardar()
    {
        // TODO: Lógica para guardar la configuración
    }

   
}

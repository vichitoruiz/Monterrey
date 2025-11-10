using System.Windows;
using SSEL.MONTERREY.Licensing;

namespace SSEL.MONTERREY.WPF;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // 🔐 Validación de licencia antes de cargar interfaz
        if (!LicenseValidator.ValidateAtStartup())
        {
            new LicenseForm().ShowDialog();
            if (!LicenseValidator.ValidateAtStartup())
            {
                Current.Shutdown();
                return;
            }
        }

        // ✅ Abrir ventana principal (Dashboard WPF)
        new MainWindow().Show();
    }
}

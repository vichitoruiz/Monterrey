using System.Windows.Forms;

namespace SSEL.MONTERREY.WinForms.Forms;

public class FrmConfiguracion : Form
{
    public FrmConfiguracion()
    {
        Text = "Configuración del Sistema";
        Width = 600;
        Height = 400;
        var lbl = new Label
        {
            Text = "Aquí se configurarán los datos de empresa, API Perú, logos y tolerancias.",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        };
        Controls.Add(lbl);
    }
}

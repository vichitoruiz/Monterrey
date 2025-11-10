using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SSEL.MONTERREY.Application.Interfaces;

namespace SSEL.MONTERREY.WinForms.Forms;

public class FrmRecibos : Form
{
    private readonly IReciboService _srv;
    private readonly DataGridView dgv = new() { Dock = DockStyle.Fill };
    private readonly TextBox txtPeriodo = new() { PlaceholderText = "AAAA-MM" };
    private readonly Button btnGenerar = new() { Text = "Generar Recibo" };

    public FrmRecibos(IServiceProvider sp)
    {
        _srv = sp.GetRequiredService<IReciboService>();
        Text = "Recibos Emitidos";

        var panelTop = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40 };
        panelTop.Controls.AddRange([txtPeriodo, btnGenerar]);
        Controls.AddRange([panelTop, dgv]);

        btnGenerar.Click += async (_, _) =>
        {
            await _srv.GenerarReciboAsync(1, 1); // Ejemplo: usuario 1, lectura 1
            MessageBox.Show("Recibo generado.");
        };
    }
}

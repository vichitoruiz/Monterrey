using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SSEL.MONTERREY.Application.Interfaces;
using SSEL.MONTERREY.Application.DTOs;
using System.Linq;
using System;

namespace SSEL.MONTERREY.WinForms.Forms;

public class FrmLecturas : Form
{
    private readonly ILecturaService _srv;
    private readonly DataGridView dgv = new() { Dock = DockStyle.Fill };
    private readonly TextBox txtPeriodo = new() { PlaceholderText = "AAAA-MM" };
    private readonly Button btnBuscar = new() { Text = "Buscar" };

    public FrmLecturas(IServiceProvider sp)
    {
        _srv = sp.GetRequiredService<ILecturaService>();
        Text = "Lecturas de Suministro";

        var panelTop = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40 };
        panelTop.Controls.AddRange([txtPeriodo, btnBuscar]);
        Controls.AddRange([panelTop, dgv]);

        btnBuscar.Click += async (_, _) =>
        {
            var data = await _srv.ListarPorPeriodoAsync(txtPeriodo.Text);
            dgv.DataSource = data.ToList();
        };
    }
}

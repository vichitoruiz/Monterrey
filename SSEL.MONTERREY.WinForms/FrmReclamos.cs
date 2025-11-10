using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SSEL.MONTERREY.Application.Interfaces;
using SSEL.MONTERREY.Application.DTOs;
using System.Linq;
using System;

namespace SSEL.MONTERREY.WinForms.Forms;

public class FrmReclamos : Form
{
    private readonly IReclamoService _srv;
    private readonly DataGridView dgv = new() { Dock = DockStyle.Fill };
    private readonly TextBox txtDesc = new() { PlaceholderText = "Describa su reclamo..." };
    private readonly Button btnGuardar = new() { Text = "Registrar" };

    public FrmReclamos(IServiceProvider sp)
    {
        _srv = sp.GetRequiredService<IReclamoService>();
        Text = "Reclamos de Usuarios";

        var panelTop = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40 };
        panelTop.Controls.AddRange([txtDesc, btnGuardar]);
        Controls.AddRange([panelTop, dgv]);

        Load += async (_, _) =>
        {
            var reclamos = await _srv.ListarAsync();
            dgv.DataSource = reclamos.ToList();
        };

        btnGuardar.Click += async (_, _) =>
        {
            await _srv.RegistrarAsync(new ReclamoDTO { UsuarioId = 1, Descripcion = txtDesc.Text });
            MessageBox.Show("Reclamo registrado correctamente.");
        };
    }
}


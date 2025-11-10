using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SSEL.MONTERREY.Application.Interfaces;
using SSEL.MONTERREY.Application.DTOs;
using System;

namespace SSEL.MONTERREY.WinForms.Forms;

public class FrmUsuarios : Form
{
    private readonly IUsuarioService _srv;
    private readonly DataGridView dgv = new() { Dock = DockStyle.Fill };

    public FrmUsuarios(IServiceProvider sp)
    {
        _srv = sp.GetRequiredService<IUsuarioService>();
        Text = "Gestión de Usuarios";
        Load += async (_, _) =>
        {
            var lista = await _srv.ListarAsync();
            dgv.DataSource = lista.ToList();
        };
        Controls.Add(dgv);
    }
}

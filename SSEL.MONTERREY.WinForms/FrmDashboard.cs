using System.Windows.Forms;
using SSEL.MONTERREY.WinForms.Utils;
using Microsoft.Extensions.DependencyInjection;
using SSEL.MONTERREY.Application.Interfaces;
using System.Drawing;
using System;

namespace SSEL.MONTERREY.WinForms.Forms;

public class FrmDashboard : Form
{
    private readonly IServiceProvider _services;
    private readonly Panel pnlMenu = new();
    private readonly Panel pnlContenido = new();

    public FrmDashboard(IServiceProvider services)
    {
        _services = services;

        Text = "SSEL MONTERREY - Panel Principal";
        WindowState = FormWindowState.Maximized;
        BackColor = ThemeManager.FondoPrincipal;

        // Menú lateral
        pnlMenu.Dock = DockStyle.Left;
        pnlMenu.Width = 200;
        pnlMenu.BackColor = ThemeManager.AzulPrimario;

        var btnUsuarios = CrearBoton("Usuarios");
        var btnLecturas = CrearBoton("Lecturas");
        var btnRecibos = CrearBoton("Recibos");
        var btnReclamos = CrearBoton("Reclamos");
        var btnConfig = CrearBoton("Configuración");
        var btnAcerca = CrearBoton("Acerca de");

        btnUsuarios.Click += (_, _) => AbrirFormulario(new FrmUsuarios(_services));
        btnLecturas.Click += (_, _) => AbrirFormulario(new FrmLecturas(_services));
        btnRecibos.Click += (_, _) => AbrirFormulario(new FrmRecibos(_services));
        btnReclamos.Click += (_, _) => AbrirFormulario(new FrmReclamos(_services));
        btnConfig.Click += (_, _) => AbrirFormulario(new FrmConfiguracion());
        btnAcerca.Click += (_, _) => AbrirFormulario(new FrmAcercaDe());

        pnlMenu.Controls.AddRange([btnUsuarios, btnLecturas, btnRecibos, btnReclamos, btnConfig, btnAcerca]);

        // Contenedor principal
        pnlContenido.Dock = DockStyle.Fill;
        Controls.AddRange([pnlMenu, pnlContenido]);
    }

    private Button CrearBoton(string texto)
    {
        return new Button
        {
            Text = texto,
            Dock = DockStyle.Top,
            Height = 45,
            FlatStyle = FlatStyle.Flat,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            BackColor = ThemeManager.AzulPrimario
        };
    }

    private void AbrirFormulario(Form form)
    {
        pnlContenido.Controls.Clear();
        form.TopLevel = false;
        form.Dock = DockStyle.Fill;
        pnlContenido.Controls.Add(form);
        form.Show();
    }
}

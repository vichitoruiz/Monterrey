using System.Windows.Forms;
using SSEL.MONTERREY.WinForms.Utils;

namespace SSEL.MONTERREY.WinForms.Forms;

public class FrmLogin : Form
{
    private readonly TextBox txtUsuario = new();
    private readonly TextBox txtClave = new();
    private readonly Button btnIngresar = new();

    public FrmLogin()
    {
        Text = "Inicio de Sesión - SSEL MONTERREY";
        Width = 400; Height = 280;
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = ThemeManager.FondoPrincipal;

        var lblUser = new Label { Text = "Usuario:", Left = 60, Top = 60 };
        var lblPass = new Label { Text = "Contraseña:", Left = 60, Top = 100 };

        txtUsuario.SetBounds(150, 58, 160, 25);
        txtClave.SetBounds(150, 98, 160, 25);
        txtClave.PasswordChar = '•';

        btnIngresar.Text = "Ingresar";
        btnIngresar.SetBounds(150, 140, 100, 30);
        btnIngresar.Click += (_, _) =>
        {
            if (txtUsuario.Text == "admin" && txtClave.Text == "123")
            {
                Hide();
                new FrmDashboard(null!).ShowDialog();
                Close();
            }
            else
                MessageBox.Show("Credenciales incorrectas.", "SSEL MONTERREY",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        };

        Controls.AddRange([lblUser, lblPass, txtUsuario, txtClave, btnIngresar]);
    }
}

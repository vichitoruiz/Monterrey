using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSEL.MONTERREY.WinForms.Forms
{
    public partial class FrmAcercaDe : Form
    {
        public FrmAcercaDe()
        {
            Text = "Acerca de SSEL MONTERREY";
            ClientSize = new Size(500, 300);
            StartPosition = FormStartPosition.CenterScreen;

            var lbl = new Label
            {
                Text = "SSEL MONTERREY\nSistema de Suministro Eléctrico Local\nVersión 3.4\nDesarrollado por Vichitoruiz © 2025",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 11)
            };

            Controls.Add(lbl);
        }
    }
}

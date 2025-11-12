using System;
﻿using System;
using System.Windows.Forms;
using System.Management;

namespace SSEL.MONTERREY.Licensing
{
    public partial class LicenseForm : Form
    {
        private readonly TextBox txtLic;
        private readonly Button btnGuardar;

        public LicenseForm()
        {
            InitializeComponent();

            Text = "Gestión de Licencia - SSEL MONTERREY";
            Width = 500;
            Height = 250;
            StartPosition = FormStartPosition.CenterParent;

            var lbl = new Label
            {
                Text = "Ingrese la licencia provista:",
                Left = 20,
                Top = 20,
                Width = 400
            };

            txtLic = new TextBox
            {
                Multiline = true,
                Width = 400,
                Height = 80,
                Left = 20,
                Top = 50
            };

            btnGuardar = new Button
            {
                Text = "Guardar Licencia",
                Left = 20,
                Top = 150
            };
            btnGuardar.Click += (_, _) => GuardarLicencia();

            Controls.AddRange(new Control[] { lbl, txtLic, btnGuardar });
        }

        private void GuardarLicencia()
        {
            try
            {
                var model = new LicenseModel
                {
                    LicensedTo = "Cliente Local",
                    LicenseKey = txtLic.Text.Trim(),
                    HardwareId = HWIDGenerator.GetHardwareId(),
                    ExpirationDate = DateTime.Today.AddYears(1)
                };

                LicenseManager.SaveLicense(model);

                MessageBox.Show("Licencia registrada correctamente.", "SSEL MONTERREY",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar licencia: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

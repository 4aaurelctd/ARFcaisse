using System;
using System.Windows.Forms;

namespace SkateparkManagement
{
    public partial class HoursManagementForm : Form
    {
        public HoursManagementForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Gestion des Heures d'Ouverture";
            this.Size = new System.Drawing.Size(400, 300);

            // Create controls for managing hours...

            Button btnBack = new Button() { Text = "Retour", Left = 50, Top = 140, Width = 300 };
            btnBack.Click += (sender, e) => this.Hide();

            this.Controls.Add(btnBack);
        }
    }
}

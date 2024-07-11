using System;
using System.Windows.Forms;

namespace SkateparkManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Main Menu";
            this.Size = new System.Drawing.Size(400, 300);

            Button btnCashRegister = new Button() { Text = "Caisse", Left = 50, Top = 20, Width = 300 };
            Button btnUserManagement = new Button() { Text = "Gestion des utilisateurs", Left = 50, Top = 50, Width = 300 };
            Button btnHoursManagement = new Button() { Text = "Gestion des heures d'ouverture", Left = 50, Top = 80, Width = 300 };
            Button btnArticleManagement = new Button() { Text = "Gestion des articles", Left = 50, Top = 110, Width = 300 };
            Button btnSalesReports = new Button() { Text = "Rapports de ventes", Left = 50, Top = 140, Width = 300 };

            btnCashRegister.Click += (sender, e) => new CashRegisterForm().Show();
            btnUserManagement.Click += (sender, e) => new UserManagementForm().Show();
            btnHoursManagement.Click += (sender, e) => new HoursManagementForm().Show();
            btnArticleManagement.Click += (sender, e) => new ArticleManagementForm().Show();

            this.Controls.Add(btnCashRegister);
            this.Controls.Add(btnUserManagement);
            this.Controls.Add(btnHoursManagement);
            this.Controls.Add(btnArticleManagement);
            this.Controls.Add(btnSalesReports);
        }
    }
}

using System;
using System.Windows.Forms;

namespace SkateparkManagement
{
    public partial class UserManagementForm : Form
    {
        public UserManagementForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Gestion des Utilisateurs";
            this.Size = new System.Drawing.Size(400, 300);

            Button btnAddUser = new Button() { Text = "Ajouter Utilisateur", Left = 50, Top = 20, Width = 300 };
            Button btnDeleteUser = new Button() { Text = "Supprimer Utilisateur", Left = 50, Top = 50, Width = 300 };
            Button btnUpdateUser = new Button() { Text = "Modifier Utilisateur", Left = 50, Top = 80, Width = 300 };
            Button btnChangePin = new Button() { Text = "Changer PIN", Left = 50, Top = 110, Width = 300 };
            Button btnBack = new Button() { Text = "Retour", Left = 50, Top = 140, Width = 300 };

            btnAddUser.Click += (sender, e) => new UserForm(ActionType.Add).Show();
            btnDeleteUser.Click += (sender, e) => new UserForm(ActionType.Delete).Show();
            btnUpdateUser.Click += (sender, e) => new UserForm(ActionType.Update).Show();
            btnChangePin.Click += (sender, e) => new UserForm(ActionType.ChangePin).Show();

            btnBack.Click += (sender, e) => this.Hide();

            this.Controls.Add(btnAddUser);
            this.Controls.Add(btnDeleteUser);
            this.Controls.Add(btnUpdateUser);
            this.Controls.Add(btnChangePin);
            this.Controls.Add(btnBack);
        }
    }
}

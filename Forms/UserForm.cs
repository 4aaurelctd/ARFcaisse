using System;
using System.Linq;
using System.Windows.Forms;

namespace SkateparkManagement
{
    public enum ActionType { Add, Delete, Update, ChangePin }

    public partial class UserForm : Form
    {
        private ActionType actionType;

        public UserForm(ActionType actionType)
        {
            this.actionType = actionType;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = actionType.ToString();
            this.Size = new System.Drawing.Size(400, 300);

            TextBox txtName = new TextBox() { Left = 50, Top = 20, Width = 300 };
            TextBox txtSurname = new TextBox() { Left = 50, Top = 50, Width = 300 };
            TextBox txtPin = new TextBox() { Left = 50, Top = 80, Width = 300, PasswordChar = '*' };
            Button btnSubmit = new Button() { Text = "Submit", Left = 50, Top = 110, Width = 300 };
            Button btnBack = new Button() { Text = "Retour", Left = 50, Top = 140, Width = 300 };

            btnSubmit.Click += (sender, e) => BtnSubmit_Click(txtName.Text, txtSurname.Text, txtPin.Text);
            btnBack.Click += (sender, e) => this.Hide();

            this.Controls.Add(txtName);
            this.Controls.Add(txtSurname);
            this.Controls.Add(txtPin);
            this.Controls.Add(btnSubmit);
            this.Controls.Add(btnBack);

            if (actionType == ActionType.Delete || actionType == ActionType.Update || actionType == ActionType.ChangePin)
            {
                ComboBox cbUsers = new ComboBox() { Left = 50, Top = 20, Width = 300 };
                cbUsers.Items.AddRange(Database.Users.Select(u => u.Name).ToArray());
                cbUsers.SelectedIndexChanged += (sender, e) => CbUsers_SelectedIndexChanged(cbUsers.SelectedItem.ToString(), txtName, txtSurname, txtPin);
                this.Controls.Add(cbUsers);
                txtName.Top = 50;
                txtSurname.Top = 80;
                txtPin.Top = 110;
                btnSubmit.Top = 140;
                btnBack.Top = 170;
            }
        }

        private void CbUsers_SelectedIndexChanged(string selectedUser, TextBox txtName, TextBox txtSurname, TextBox txtPin)
        {
            var user = Database.Users.FirstOrDefault(u => u.Name == selectedUser);
            if (user != null)
            {
                txtName.Text = user.Name;
                txtSurname.Text = user.Surname;
                txtPin.Text = user.Pin;
            }
        }

        private void BtnSubmit_Click(string name, string surname, string pin)
        {
            switch (actionType)
            {
                case ActionType.Add:
                    Database.Users.Add(new User { Name = name, Surname = surname, Pin = pin });
                    break;
                case ActionType.Delete:
                    var userToDelete = Database.Users.FirstOrDefault(u => u.Name == name);
                    if (userToDelete != null) Database.Users.Remove(userToDelete);
                    break;
                case ActionType.Update:
                    var userToUpdate = Database.Users.FirstOrDefault(u => u.Name == name);
                    if (userToUpdate != null)
                    {
                        userToUpdate.Name = name;
                        userToUpdate.Surname = surname;
                        userToUpdate.Pin = pin;
                    }
                    break;
                case ActionType.ChangePin:
                    var userToChangePin = Database.Users.FirstOrDefault(u => u.Name == name);
                    if (userToChangePin != null) userToChangePin.Pin = pin;
                    break;
            }

            Database.Save();
            this.Hide();
        }
    }
}

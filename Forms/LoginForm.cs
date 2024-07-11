using System;
using System.Windows.Forms;

namespace SkateparkManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Login";
            this.Size = new System.Drawing.Size(300, 200);

            ComboBox cbEmployees = new ComboBox() { Left = 50, Top = 20, Width = 200 };
            TextBox txtPin = new TextBox() { Left = 50, Top = 50, Width = 200, PasswordChar = '*' };
            Button btnLogin = new Button() { Text = "Login", Left = 50, Top = 80, Width = 200 };
            Button btnGuest = new Button() { Text = "Guest Login", Left = 50, Top = 110, Width = 200 };

            btnLogin.Click += (sender, e) => BtnLogin_Click(cbEmployees.Text, txtPin.Text);
            btnGuest.Click += (sender, e) => BtnGuest_Click();

            this.Controls.Add(cbEmployees);
            this.Controls.Add(txtPin);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnGuest);
        }

        private void BtnLogin_Click(string employeeName, string pin)
        {
            if (PinValidator.ValidatePin(employeeName, pin))
            {
                this.Hide();
                new MainForm().Show();
            }
            else
            {
                MessageBox.Show("Invalid PIN");
            }
        }

        private void BtnGuest_Click()
        {
            this.Hide();
            new MainForm().Show();
        }
    }
}

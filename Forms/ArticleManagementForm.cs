using System;
using System.Windows.Forms;

namespace SkateparkManagement
{
    public partial class ArticleManagementForm : Form
    {
        public ArticleManagementForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Gestion des Articles";
            this.Size = new System.Drawing.Size(400, 300);

            Button btnAddArticle = new Button() { Text = "Ajouter Article", Left = 50, Top = 20, Width = 300 };
            Button btnDeleteArticle = new Button() { Text = "Supprimer Article", Left = 50, Top = 50, Width = 300 };
            Button btnUpdateArticle = new Button() { Text = "Modifier Article", Left = 50, Top = 80, Width = 300 };
            Button btnBack = new Button() { Text = "Retour", Left = 50, Top = 110, Width = 300 };

            btnBack.Click += (sender, e) => this.Hide();

            this.Controls.Add(btnAddArticle);
            this.Controls.Add(btnDeleteArticle);
            this.Controls.Add(btnUpdateArticle);
            this.Controls.Add(btnBack);
        }
    }
}

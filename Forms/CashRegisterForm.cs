using System;
using System.Linq;
using System.Windows.Forms;

namespace SkateparkManagement
{
    public partial class CashRegisterForm : Form
    {
        public CashRegisterForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Caisse";
            this.Size = new System.Drawing.Size(800, 600);

            // Articles panel
            Panel articlesPanel = new Panel() { Left = 20, Top = 20, Width = 500, Height = 500 };
            int buttonWidth = 150, buttonHeight = 100, margin = 10;
            int columns = 3;
            int index = 0;

            foreach (var article in Database.Articles)
            {
                Button btnArticle = new Button()
                {
                    Text = $"{article.Name}\n{article.Price:C}",
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Top = (index / columns) * (buttonHeight + margin),
                    Left = (index % columns) * (buttonWidth + margin)
                };
                btnArticle.Click += (sender, e) => AddToCart(article);
                articlesPanel.Controls.Add(btnArticle);
                index++;
            }

            // Cart list
            ListBox lbCart = new ListBox() { Left = 540, Top = 20, Width = 220, Height = 300 };

            // Subtotal and Total labels
            Label lblSubtotal = new Label() { Text = "Subtotal: 0.00", Left = 540, Top = 330, Width = 220 };
            Label lblTotal = new Label() { Text = "Total: 0.00", Left = 540, Top = 360, Width = 220 };

            // Checkout button
            Button btnCheckout = new Button() { Text = "Payer", Left = 540, Top = 390, Width = 220 };
            btnCheckout.Click += (sender, e) => Checkout(lbCart, lblSubtotal, lblTotal);

            // Change given
            Label lblChange = new Label() { Text = "Change: 0.00", Left = 540, Top = 420, Width = 220 };
            TextBox txtReceived = new TextBox() { Left = 540, Top = 450, Width = 220, PlaceholderText = "Amount received" };

            // Back button
            Button btnBack = new Button() { Text = "Retour", Left = 540, Top = 490, Width = 220 };
            btnBack.Click += (sender, e) => this.Hide();

            this.Controls.Add(articlesPanel);
            this.Controls.Add(lbCart);
            this.Controls.Add(lblSubtotal);
            this.Controls.Add(lblTotal);
            this.Controls.Add(btnCheckout);
            this.Controls.Add(lblChange);
            this.Controls.Add(txtReceived);
            this.Controls.Add(btnBack);
        }

        private void AddToCart(Article article)
        {
            ListBox lbCart = (ListBox)this.Controls.OfType<ListBox>().First();
            lbCart.Items.Add(article);
            UpdateTotals(lbCart);
        }

        private void UpdateTotals(ListBox lbCart)
        {
            double subtotal = lbCart.Items.Cast<Article>().Sum(article => article.Price);
            Label lblSubtotal = (Label)this.Controls.OfType<Label>().First(l => l.Text.StartsWith("Subtotal"));
            Label lblTotal = (Label)this.Controls.OfType<Label>().First(l => l.Text.StartsWith("Total"));

            lblSubtotal.Text = $"Subtotal: {subtotal:C}";
            lblTotal.Text = $"Total: {subtotal:C}";
        }

        private void Checkout(ListBox lbCart, Label lblSubtotal, Label lblTotal)
        {
            double total = lbCart.Items.Cast<Article>().Sum(article => article.Price);
            TextBox txtReceived = (TextBox)this.Controls.OfType<TextBox>().First();
            double receivedAmount;

            if (double.TryParse(txtReceived.Text, out receivedAmount) && receivedAmount >= total)
            {
                double change = receivedAmount - total;
                Label lblChange = (Label)this.Controls.OfType<Label>().First(l => l.Text.StartsWith("Change"));

                lblChange.Text = $"Change: {change:C}";
                MessageBox.Show($"Total à payer : {total:C}\nMontant reçu : {receivedAmount:C}\nRendu de monnaie : {change:C}");

                // Enregistrer la vente
                RecordSale(lbCart.Items.Cast<Article>().ToList(), total);

                // Vider le panier et réinitialiser les montants
                lbCart.Items.Clear();
                lblSubtotal.Text = "Subtotal: 0.00";
                lblTotal.Text = "Total: 0.00";
                txtReceived.Text = string.Empty;
                lblChange.Text = "Change: 0.00";
            }
            else
            {
                MessageBox.Show("Montant insuffisant ou non valide.");
            }
        }

        private void RecordSale(List<Article> articles, double total)
        {
            var user = Database.Users.FirstOrDefault(u => u.Name == "Current User"); // Placeholder for the current user logic
            if (user != null)
            {
                user.Sales.Add(new Sale { Amount = total, Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Articles = articles });
                Database.Save();
            }
        }
    }
}

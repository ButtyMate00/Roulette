﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MM_BM_Roulette
{
    public partial class Form2 : Form
    {
        private TextBox txtName;
        private TextBox txtBalance;
        private Button btnSubmit;
        private Panel pnlForm2;
        private Label lblbev;

        public Form2()
        {
            Form2_Load(null, null);
            this.Icon = new Icon("favicon.ico");//kép: https://www.flaticon.com/free-icon/roulette_218417
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Rulett Játék";
            this.Size = new Size(500,300);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void Form2_Load(object sender, EventArgs e)
        {
            txtName = new TextBox
            {
                Text = "Add meg a neved",
                Location = new Point(145, 30),
                Size = new Size(210, 30),
                BackColor = ColorTranslator.FromHtml("#213743"),
                ForeColor = Color.White,
                TextAlign = HorizontalAlignment.Center
            };
            this.Controls.Add(txtName);

            txtBalance = new TextBox
            {
                Text = "Add meg az egyenlegedet",
                Location = new Point(145, 70),
                Size = new Size(210, 30),
                BackColor = ColorTranslator.FromHtml("#213743"),
                ForeColor = Color.White,
                TextAlign = HorizontalAlignment.Center
            };
            this.Controls.Add(txtBalance);

            btnSubmit = new Button
            {
                Text = "Megadás",
                Location = new Point(145, 100),
                Size = new Size(210, 40),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.Green,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            btnSubmit.Click += btnSubmit_Click;
            this.Controls.Add(btnSubmit);

            lblbev = new Label
            {
                Text = "Üdvözöllek a Rulett Játékben!\nKészítette: Magyar Márk és Butty Máté\nSok szerencsét a játék során!😈",
                Location = new Point(5, 120),
                Size = new Size(500, 140),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White
            };
            this.Controls.Add(lblbev);

            pnlForm2 = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(500, 300),
                BackColor = ColorTranslator.FromHtml("#08121A")
            };
            this.Controls.Add(pnlForm2);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string playerName = txtName.Text;
            string balanceInput = txtBalance.Text;
            decimal playerBalance;

            // név ell
            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Kérlek, add meg a neved!", "Hiányzó név", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // egyenleg ell
            if (!decimal.TryParse(balanceInput, out playerBalance) || playerBalance <= 0)
            {
                MessageBox.Show("Kérlek, adj meg egy érvényes, pozitív egyenleget!", "Hiányzó vagy érvénytelen egyenleg", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Üdv, {playerName}! Az egyenleged: {playerBalance} Ft", "Játék indul", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1 mainForm = new Form1(playerName, playerBalance);
            mainForm.Show();
            this.Hide();
        }
    }
}
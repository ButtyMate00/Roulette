﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MM_BM_Roulette
{
    public partial class Form1 : Form
    {
        TextBox fixmoney = new TextBox();
        TextBox txtMoney = new TextBox();
        Button btnBet = new Button();
        Label lblWin = new Label();
        Panel panel1 = new Panel();
        Panel panel2 = new Panel();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fixmoney.Text = "Money: 1000";
            fixmoney.Location = new Point(35, 10);
            fixmoney.Size = new Size(200, 20);
            fixmoney.Enabled = false;
            fixmoney.Font = new Font(txtMoney.Font, FontStyle.Bold);
            this.Controls.Add(fixmoney);

            txtMoney.Text = "összeg";
            txtMoney.Location = new Point(35, 40);
            txtMoney.Size = new Size(200, 20);
            txtMoney.BackColor = Color.Gray;
            txtMoney.Font = new Font(txtMoney.Font, FontStyle.Bold);
            txtMoney.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(txtMoney);

            btnBet.Text = "Bet";
            btnBet.Location = new Point(35, 70);
            btnBet.Size = new Size(200, 30);
            btnBet.BackColor = Color.Green;
            btnBet.TextAlign = ContentAlignment.MiddleCenter;
            btnBet.Font = new Font(btnBet.Font, FontStyle.Bold);
            btnBet.Click += new EventHandler(btnBet_Click);
            this.Controls.Add(btnBet);
            lblWin.Text = "0";

            
            panel1.Dock = DockStyle.Left;
            panel1.BackColor = ColorTranslator.FromHtml("#08121A");
            panel1.Size = new Size(this.Width, this.Height);
            this.Controls.Add(panel1);

            panel2.Dock = DockStyle.Left;
            panel2.BackColor = ColorTranslator.FromHtml("#213743");
            panel2.Size = new Size(250, this.Height);
            this.Controls.Add(panel2);
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            
        }
    }
}

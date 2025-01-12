﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MM_BM_Roulette
{
    public partial class Form1 : Form
    {
        private TextBox txtMoney;
        private TextBox txtBetAmount;
        private Label lblResult;
        private Label stat;
        private Button btnRed;
        private Button btnSpin;
        private Button btnBlack;
        private Button btn1to12;
        private Button btn13to24;
        private Button btn25to36;
        private Button btn19to36;
        private Button btn1to18;
        private Button Odd;
        private Button Even;
        private Button S112;
        private Button S212;
        private Button S312;
        private Button[] numberButtons;
        private Panel panel1;
        private Panel panel2;

        private int playerMoney = 0;
        private int JelenlegiTet = 0;
        private string tet = "";
        private string PlayerName { get; set; }
        private decimal PlayerBalance { get; set; }

        public Form1(string playerName, decimal playerBalance)
        {
            InitializeComponent();
            this.Icon = new Icon("favicon.ico");//kép: https://www.flaticon.com/free-icon/roulette_218417
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Rulett Játék";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            PlayerName = playerName;
            PlayerBalance = playerBalance;
            playerMoney = (int)PlayerBalance;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // játékos pénze
            txtMoney = new TextBox
            {
                Text = $"Pénz: {playerMoney}",
                Location = new Point(20, 20),
                Size = new Size(210, 30),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Center,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Enabled = false
            };
            this.Controls.Add(txtMoney);

            // tét összeg megadása
            txtBetAmount = new TextBox
            {
                Text = "Add meg a tétet",
                Location = new Point(20, 60),
                Size = new Size(210, 30),
                TextAlign = HorizontalAlignment.Center
            };
            this.Controls.Add(txtBetAmount);

            // pörgetés gomb
            btnSpin = new Button
            {
                Text = "Pörgetés",
                Location = new Point(20, 90),
                Size = new Size(210, 40),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.Green,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            btnSpin.Click += BtnSpin_Click;
            this.Controls.Add(btnSpin);

            // eredmény jelző
            lblResult = new Label
            {
                Text = "Helyezd el a téted!",
                Location = new Point(20, 140),
                Size = new Size(210, 30),
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Popup,
            };
            this.Controls.Add(lblResult);

            // piros gomb
            btnRed = new Button
            {
                Location = new Point(518, 500),
                Size = new Size(100, 50),
                BackColor = Color.Red,
                ForeColor = Color.Red,
                FlatStyle = FlatStyle.Popup

            };
            btnRed.Click += (s, n) => SetBet("Piros");
            this.Controls.Add(btnRed);

            //feket gomb
            btnBlack = new Button
            {
                Location = new Point(618, 500),
                Size = new Size(100, 50),
                BackColor = Color.Black,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Popup
            };
            btnBlack.Click += (s, n) => SetBet("Fekete");
            this.Controls.Add(btnBlack);

            btn1to12 = new Button
            {
                Text = "1 to 12",
                Location = new Point(320, 450),
                Size = new Size(200, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            btn1to12.Click += (s, n) => SetBet("1to12");
            this.Controls.Add(btn1to12);

            btn1to18 = new Button
            {
                Text = "1 to 18",
                Location = new Point(320, 500),
                Size = new Size(100, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            btn1to18.Click += (s, n) => SetBet("1to18");
            this.Controls.Add(btn1to18);

            btn13to24 = new Button
            {
                Text = "13 to 24",
                Location = new Point(520, 450),
                Size = new Size(200, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            btn13to24.Click += (s, n) => SetBet("13to24");
            this.Controls.Add(btn13to24);

            btn19to36 = new Button
            {
                Text = "19 to 36",
                Location = new Point(820, 500),
                Size = new Size(100, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            btn19to36.Click += (s, n) => SetBet("19to36");
            this.Controls.Add(btn19to36);

            btn25to36 = new Button
            {
                Text = "25 to 36",
                Location = new Point(720, 450),
                Size = new Size(200, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            btn25to36.Click += (s, n) => SetBet("25to36");
            this.Controls.Add(btn25to36);

            Odd = new Button
            {
                Text = "Odd",
                Location = new Point(720, 500),
                Size = new Size(100, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            Odd.Click += (s, n) => SetBet("Odd");
            this.Controls.Add(Odd);

            Even = new Button
            {
                Text = "Even",
                Location = new Point(420, 500),
                Size = new Size(100, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            Even.Click += (s, n) => SetBet("Even");
            this.Controls.Add(Even);

            S112 = new Button
            {
                Text = "2:1",
                Location = new Point(920, 300),
                Size = new Size(50, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            S112.Click += (s, n) => SetBet("Első 2:1");
            this.Controls.Add(S112);

            S212 = new Button
            {
                Text = "2:1",
                Location = new Point(920, 350),
                Size = new Size(50, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            S212.Click += (s, n) => SetBet("Második 2:1");
            this.Controls.Add(S212);

            S312 = new Button
            {
                Text = "2:1",
                Location = new Point(920, 400),
                Size = new Size(50, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            S312.Click += (s, n) => SetBet("Harmadik 2:1");
            this.Controls.Add(S312);

            //szám gombok
            string[,] szamok = new string[,]
            {
                { "", "", "", "", "", "", "", "", "", "", "", "", "" },
                { "", "3", "6", "9", "12", "15", "18", "21", "24", "27", "30", "33", "36" },
                { "0", "2", "5", "8", "11", "14", "17", "20", "23", "26", "29", "32", "35" },
                { "", "1", "4", "7", "10", "13", "16", "19", "22", "25", "28", "31", "34" }
            };

            numberButtons = new Button[37];

            for (int oszlop = 0; oszlop < szamok.GetLength(0); oszlop++)
            {
                for (int sor = 0; sor < szamok.GetLength(1); sor++)
                {
                    string szg = szamok[oszlop, sor];
                    if (string.IsNullOrEmpty(szg)) continue;

                    int szam = int.Parse(szg);
                    numberButtons[szam] = new Button
                    {
                        Text = szg,
                        Size = (szam == 0) ? new Size(60, 150) : new Size(50, 50),
                        Location = (szam == 0) ? new Point(260, 300) : new Point(270 + sor * 50, 250 + oszlop * 50),
                        BackColor = (szam == 0) ? Color.Green : (IsRed(szam) ? Color.Red : Color.Black),
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Popup,
                    };

                    // esemény kezelés könnyítése
                    int Kszam = szam;
                    numberButtons[szam].Click += (s, n) => SetBet(Kszam.ToString());

                    this.Controls.Add(numberButtons[szam]);
                }
            }

            //panel bal oldal szín beállítás
            panel1 = new Panel
            {
                Dock = DockStyle.Left,
                BackColor = ColorTranslator.FromHtml("#08121A"),
                Size = new Size(1000, 600)
            };
            this.Controls.Add(panel1);

            //panel jobb oldal beállítás
            panel2 = new Panel
            {
                Dock = DockStyle.Left,
                BackColor = ColorTranslator.FromHtml("#213743"),
                Size = new Size(250, 800)
            };
            this.Controls.Add(panel2);
        }

        public bool IsRed(int number)
        {
            // Rulett piros mezők számai
            int[] redNumbers = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
            return Array.Exists(redNumbers, n => n == number);
        }
        private void SetBet(string type)
        {
            tet = type;
            lblResult.Text = $"Tét elhelyezve: {type}";
        }
        private void BtnSpin_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBetAmount.Text, out JelenlegiTet) || JelenlegiTet <= 0)
            {
                MessageBox.Show("Érvényes tétet adj meg!", "Érvénytelen tét", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (JelenlegiTet > playerMoney)
            {
                MessageBox.Show("Nincs elég pénzed ehhez a fogadáshoz.", "Nincs elég pénz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tet))
            {
                MessageBox.Show("Helyezd el a téted a pörgetés előtt!", "Tét hiányzik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            playerMoney -= JelenlegiTet;
            txtMoney.Text = $"Pénz: {playerMoney}";

            Random random = new Random();
            int Gyszam = random.Next(0, 37);
            int kifizetes;
            string kiSzin = (Gyszam == 0) ? "Zöld" : (IsRed(Gyszam) ? "Piros" : "Fekete");

            lblResult.Text = $"Nyertes szám: {Gyszam} ({kiSzin})";

            if (tet == "Piros"  && kiSzin == "Piros" ||
                tet == "Fekete" && kiSzin == "Fekete")
            {
                kifizetes  = JelenlegiTet * 2;
                playerMoney += kifizetes;
                txtMoney.Text = $"Pénz: {playerMoney}";
                MessageBox.Show($"Nyertél! Nyeremény: {kifizetes}", "Gratulálok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (tet == "1to12"  && (Gyszam >= 1 || Gyszam >= 2 || Gyszam >= 3 || Gyszam >= 4 || Gyszam >= 5 || Gyszam >= 6 || Gyszam >= 7 || Gyszam >= 8 || Gyszam >= 9 || Gyszam >= 10 || Gyszam >= 11 || Gyszam >= 12) ||
                tet == "13to24" && (Gyszam >= 13 || Gyszam >= 14 || Gyszam >= 15 || Gyszam >= 16 || Gyszam >= 17 || Gyszam >= 18 || Gyszam >= 19 || Gyszam >= 20 || Gyszam >= 21 || Gyszam >= 22 || Gyszam >= 23 || Gyszam >= 24) ||
                tet == "25to36" && (Gyszam >= 25 || Gyszam >= 26 || Gyszam >= 27 || Gyszam >= 28 || Gyszam >= 29 || Gyszam >= 30 || Gyszam >= 31 || Gyszam >= 32 || Gyszam >= 33 || Gyszam >= 34 || Gyszam >= 35 || Gyszam >= 36))
            {
                kifizetes = JelenlegiTet * 3; // 3x szorzó
                playerMoney += kifizetes;
                txtMoney.Text = $"Pénz: {playerMoney}";
                MessageBox.Show($"Nyertél! Nyeremény: {kifizetes}", "Gratulálok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (tet == "Odd" && Gyszam % 2 == 1 || tet == "Even" && Gyszam % 2 == 0)
            {
                kifizetes = JelenlegiTet * 2; // 2x szorzó
                playerMoney += kifizetes;
                txtMoney.Text = $"Pénz: {playerMoney}";
                MessageBox.Show($"Nyertél! Nyeremény: {kifizetes}", "Gratulálok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (tet == "Első sor 2:1"     && (Gyszam == 3 || Gyszam == 6 || Gyszam == 9 || Gyszam == 12 || Gyszam == 15 || Gyszam == 18) || Gyszam == 21 || Gyszam == 24 || Gyszam == 27 || Gyszam == 30 || Gyszam == 33 || Gyszam == 36 ||
                tet == "Második sor 2:1"  && (Gyszam == 2 || Gyszam == 5 || Gyszam == 8 || Gyszam == 11 || Gyszam == 14 || Gyszam == 17) || Gyszam == 20 || Gyszam == 23 || Gyszam == 26 || Gyszam == 29 || Gyszam == 32 || Gyszam == 35 ||
                tet == "Harmadik sor 2:1" && (Gyszam == 1 || Gyszam == 4 || Gyszam == 7 || Gyszam == 10 || Gyszam == 13 || Gyszam == 16) || Gyszam == 19 || Gyszam == 22 || Gyszam == 25 || Gyszam == 28 || Gyszam == 31 || Gyszam == 34)
            {
                kifizetes = JelenlegiTet * 3; // 3x szorzó
                playerMoney += kifizetes;
                txtMoney.Text = $"Pénz: {playerMoney}";
                MessageBox.Show($"Nyertél! Nyeremény: {kifizetes}", "Gratulálok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vesztettél. Próbáld újra!", "Sajnálom", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            tet = "";
        }
    }
}
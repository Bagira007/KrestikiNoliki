using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security;
namespace AppCSharp
{
    public partial class Form1 : Form
    {
        private Button[,] buttons  = new Button[3,3];
        private int player;
        private int k=0;
        public Form1()
        {
            InitializeComponent();
            this.Height = 530;
            this.Width = 680;
            player = 1;
            label1.Font = new Font(new FontFamily("Microsoft Sans Serif"), 14);
            label1.Text = "Ходит крестик";
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(150, 150);
                }
            }
            setButtons();         
        }

        private void setButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    buttons[i, j].Location = new Point(12 + 160 * j, 12 + 160 * i);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 100);
                    buttons[i, j].Text = " ";
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, "X");
                    player = 0;
                    label1.Text = "Ходит нолик";
                    break;
                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, "O");
                    player = 1;
                    label1.Text = "Ходит крестик";
                    break;
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            checkWin();
        }
        private void checkWin()
        {
            k++;
            if (
(buttons[0, 0].Text == "X" && buttons[0, 1].Text == "X" && buttons[0, 2].Text == "X") ||
(buttons[1, 0].Text == "X" && buttons[1, 1].Text == "X" && buttons[1, 2].Text == "X") ||
(buttons[2, 0].Text == "X" && buttons[2, 1].Text == "X" && buttons[2, 2].Text == "X") ||
(buttons[0, 0].Text == "X" && buttons[1, 0].Text == "X" && buttons[2, 0].Text == "X") ||
(buttons[0, 1].Text == "X" && buttons[1, 1].Text == "X" && buttons[2, 1].Text == "X") ||
(buttons[0, 2].Text == "X" && buttons[1, 2].Text == "X" && buttons[2, 2].Text == "X") ||
(buttons[0, 0].Text == "X" && buttons[1, 1].Text == "X" && buttons[2, 2].Text == "X") ||
(buttons[2, 0].Text == "X" && buttons[1, 1].Text == "X" && buttons[0, 2].Text == "X") 
                    )
                {
                    MessageBox.Show("Победили крестики!");
                    k = 0;
                    clear_box();
                }
                if (
(buttons[0, 0].Text == "O" && buttons[0, 1].Text == "O" && buttons[0, 2].Text == "O") ||
(buttons[1, 0].Text == "O" && buttons[1, 1].Text == "O" && buttons[1, 2].Text == "O") ||
(buttons[2, 0].Text == "O" && buttons[2, 1].Text == "O" && buttons[2, 2].Text == "O") ||
(buttons[0, 0].Text == "O" && buttons[1, 0].Text == "O" && buttons[2, 0].Text == "O") ||
(buttons[0, 1].Text == "O" && buttons[1, 1].Text == "O" && buttons[2, 1].Text == "O") ||
(buttons[0, 2].Text == "O" && buttons[1, 2].Text == "O" && buttons[2, 2].Text == "O") ||
(buttons[0, 0].Text == "O" && buttons[1, 1].Text == "O" && buttons[2, 2].Text == "O") ||
(buttons[2, 0].Text == "O" && buttons[1, 1].Text == "O" && buttons[0, 2].Text == "O")
                    )
                {
                MessageBox.Show("Победили нолики!");
                k = 0;
                clear_box();
                }
            if (k == 9)
            {
                MessageBox.Show("Ничья!");
                k = 0;
                clear_box();
            }

        }


        private void clear_box()
        {
            player = 1;
            k = 0;
            label1.Text = "Ходит крестик";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
            }
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            player = 1;
            k = 0;
            label1.Text = "Ходит крестик";
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOGO_DA_VELHA_NEW
{
    public partial class Form1 : Form
    {
        int j_x = 0, j_o = 0, empt = 0, rds = 0;
        bool troca = true, fim = false;
        string[] texto = new string[9]
;        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button10.Text = "";

            rds = 0;
            fim = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;
            if (btn.Text == "" && fim == false)
            {
                if (troca == true)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text;
                    rds++;
                    troca = !troca;
                    Check(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rds++;
                    troca = !troca;
                    Check(2);
                } //FINAL DA ESTRUTURA
            }

        }


        void Vencedor(int PlayerQueGanhou)
        {
            fim = true;
            if (PlayerQueGanhou == 1)
            {
                j_x++;
                label4.Text = Convert.ToString(j_x);
                MessageBox.Show("JOGADOR X GANHOU !!");
                troca = true;
            }
            else
            {
                j_o++;
                label6.Text = Convert.ToString(j_o);
                MessageBox.Show("JOGADOR O GANHOU !!");
                troca = false;
            }
        }


        void Check (int CheckPlayer)
        {
            string suport = "";

            if (CheckPlayer == 1)
            {
                suport = "X";

            }

            else
            {
                suport = "O";
            }//FINAL DO SUPORT

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suport == texto[horizontal])
                {//check horizontal
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(CheckPlayer);
                        return;

                    }//final do check horizontal
                }
            }//final do loop horizontal

            //check vertical

            for (int vertical = 0; vertical < 3; vertical ++)
            {
                if (suport == texto[vertical])
                {//check vertical
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(CheckPlayer);
                        return;

                    }
                }
            }//final do loop vertical

            //check diagonais
            if (texto[0] == suport)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {

                    Vencedor(CheckPlayer);
                    return;

                }//DIAGONAL PRINCIPAL

               
            }
            if (texto[2]  == suport)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Vencedor(CheckPlayer);
                    return;
                }//DIAGONAL SECUNDARIA
            }
            if (rds == 9 && fim == false)
            {
                empt++;
                label5.Text = Convert.ToString(empt);
                MessageBox.Show("EMPATE");
                fim = true;
                return;
            }
        }
    }
}

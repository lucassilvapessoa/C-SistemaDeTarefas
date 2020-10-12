using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp2.Classes;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        private string id;
        private string[] opçoes;
        private string textoInicial;
        public Form5(string id, string[] op)
        {
            this.id = id;
            this.opçoes = new string[op.Length];
            for (int i = 0; i < op.Length; i++)
            {
                this.opçoes[i] = op[i].ToString();

            }
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = "Identificação do usuário " + this.id;
            this.Text = "Atualização de tarefas";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (var item in opçoes)
            {
                comboBox1.Items.Add(item.ToString());

            }
         
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }
            base.WndProc(ref m);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bdd bd1 = new Bdd();
            string descricao = bd1.descricao(comboBox1.SelectedItem.ToString());
            richTextBox1.Text = descricao;
            textoInicial = descricao;
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text == textoInicial)
            {
                MessageBox.Show("Não foram encontradas alterações");
            }
            else
            {
                MessageBox.Show("Atualizações reconhecidas");
                Bdd bd1 = new Bdd();
                bd1.atualizarTarefa(comboBox1.SelectedItem.ToString(), richTextBox1.Text);
              
            }
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
          
             
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}

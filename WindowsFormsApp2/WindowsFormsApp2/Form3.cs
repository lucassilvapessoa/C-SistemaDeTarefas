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
    public partial class Form3 : Form
    {

        private string nome;
        private string id;
        public Form3(string id,string nome)
        {
            this.nome = nome;
            this.id = id;
            InitializeComponent();
        }
  

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de tarefas";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.label1.Text = "Id: " + this.id;
            this.label3.Text = "Usuário: " + this.nome;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
    
            string[] opc = { "Lazer", "Estudos", "Pessoal", "Esporte" };
            foreach (var item in opc)
            {
                comboBox1.Items.Add(item);

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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
          
            if(String.IsNullOrEmpty(richTextBox1.Text) || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor preencha os campos");
            }
            else
            {
                string descricao = richTextBox1.Text;
                string opcao = comboBox1.SelectedItem.ToString();
                MessageBox.Show("Dados verificados");
                Tarefa t = new Tarefa(descricao, opcao, this.id);
                GerenciadorTarefa gt = new GerenciadorTarefa(this.id);
                gt.adicionarTarefa(t);
                this.Close();
              
            }
           
        }
    }
}

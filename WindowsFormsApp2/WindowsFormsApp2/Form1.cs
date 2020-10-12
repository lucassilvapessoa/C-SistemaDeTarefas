using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Classes;



namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
       
        Bdd bd1 = new Bdd();

        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
         
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                MessageBox.Show("Verifique o prenchimento dos campos para realizar o login");
            }
            else
            {
                if(bd1.retornaDados(textBox1.Text, Login.gerarMd5(textBox2.Text)))
                {
                    MessageBox.Show("Usuario encontrado");
                    var dados = bd1.dadosCliente(textBox1.Text, Login.gerarMd5(textBox2.Text));
                    this.Hide();
                    Form2 f2 = new Form2(this,dados[0]);
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado");
                }
            }
        }


        public bool verifica(string usuario, string senha)
        {
            bool resultado = bd1.retornaDados(usuario, senha);
            return resultado ? false : true;
        }
        public  bool verificaCampos()
        {
            return String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) ? true : false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string senha = textBox2.Text;
            if (verificaCampos())
            {
                MessageBox.Show("Verifique o preenchimento dos campos para realizar o cadastro");
            }
            else
            {
                if(verifica(login, Login.gerarMd5(senha)))
                {
                    bd1.inserirNovoLogin(login, Login.gerarMd5(senha));
                }
                else
                {
                    MessageBox.Show("Usuário e senha já existem escolha uma combinação diferente");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
          
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }
    }
}

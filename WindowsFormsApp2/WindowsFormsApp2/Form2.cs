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
    public partial class Form2 : Form
    {
        private Form1 form1;
        private string id;
        public Form2(Form1 form1, string id)
        {
            this.form1 = form1;
            this.id = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            Bdd bd1 = new Bdd();
            var dados = bd1.informacoesCliente(this.id);
            label1.Text = "Seja Bem Vindo: " + dados[1].ToString();
            label2.Text = "Id: " + dados[0].ToString();
            this.Text = "Area De Gerenciamento";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Enter(object sender, EventArgs e)
        {
      
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
     
         

            
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void button2_Layout(object sender, LayoutEventArgs e)
        {

        }
        private Form3 Form = null;
        private Form4 Form1 = null;
        private Form5 Form5 = null;
        private Form6 Form6 = null;
       
        private void button2_Click(object sender, EventArgs e)
        {
            Bdd bd1 = new Bdd();
            var dados = bd1.informacoesCliente(this.id);
            this.Form = new Form3(dados[0].ToString(),dados[1].ToString());
            this.Form.TopLevel = false;
            this.Form.Visible = true;
            this.Controls.Add(this.Form);
            this.ArrangeFormSize();
        }
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            this.ArrangeFormSize();
        }
        private void ArrangeFormSize()
        {
            this.Form.Location = new Point(
                this.ClientSize.Width - this.Form.Width - 70,
                this.ClientSize.Height - this.form1.Height - 190
                ) ; 
        }
        private void ArrangeFormSize1()
        {
            this.Form1.Location = new Point(
                this.ClientSize.Width - this.Form1.Width - 70,
                this.ClientSize.Height - this.form1.Height - 190
                );
        }
        private void ArrangeFormSize2()
        {
            this.Form5.Location = new Point(
                this.ClientSize.Width - this.Form5.Width - 70,
                this.ClientSize.Height - this.Form5.Height - 10
                ); 
        }
        private void ArrangeFormSize3()
        {
            this.Form6.Location = new Point(
                this.ClientSize.Width - this.Form6.Width - 70,
                this.ClientSize.Height - this.Form6.Height - 10
                );
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Bdd bd1 = new Bdd();
            var teste = bd1.dadosTarefas(this.id);
            this.Form5 = new Form5(this.id, teste);
            this.Form5.TopLevel = false;
            this.Form5.Visible = true;
            this.Controls.Add(this.Form5);
            this.ArrangeFormSize2();


        }

        private void Listar_Click(object sender, EventArgs e)
        {
            Bdd bd1 = new Bdd();
            var teste =  bd1.dadosTarefas(this.id);
            this.Form1 = new Form4(this.id,teste);
            this.Form1.TopLevel = false;
            this.Form1.Visible = true;
            this.Controls.Add(this.Form1);
            this.ArrangeFormSize1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bdd bd1 = new Bdd();
            var teste = bd1.dadosTarefas(this.id);
            this.Form6 = new Form6(this.id, teste);
            this.Form6.TopLevel = false;
            this.Form6.Visible = true;
            this.Controls.Add(this.Form6);
            this.ArrangeFormSize3();
        }
    }
}

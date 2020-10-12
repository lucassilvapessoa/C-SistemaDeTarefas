using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp2
{
    class Tarefa
    {
        private string descricao;
        private string tipo;
        private string donoDaTarefa;
        public Tarefa(string des, string tip,string dt)
        {
            this.descricao = des;
            this.tipo = tip;
            this.donoDaTarefa = dt;
        }

        public string getDescricao()
        {
            return this.descricao;
        }
        public string getTipo()
        {
            return this.tipo;
        }
        public string getIdDono()
        {
            return this.donoDaTarefa;
        }
    }
}

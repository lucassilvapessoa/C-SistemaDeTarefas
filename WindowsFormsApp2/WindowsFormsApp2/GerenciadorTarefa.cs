using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp2.Classes;

namespace WindowsFormsApp2
{
    class GerenciadorTarefa
    {
        private string id;
        private Bdd bd1;
        public GerenciadorTarefa(string dono)
        {
            this.id = dono;
        }
        public string getId()
        {
            return id;
        }
        public void adicionarTarefa(Tarefa tarefa)
        {
            bd1 = new Bdd();
            bd1.inserirNovaTarefa(tarefa);
        }

    }
}

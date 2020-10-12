using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp2.Classes
{
    class Bdd
    {
        private static MySqlConnection GerarConexao()
        {
            string cs = @"server=localhost;userid=root;password=;database=teste3";
            var con = new MySqlConnection(cs);
            return con;
        }
        public void inserirNovoLogin(string usuario, string senha)
        {
            MySqlConnection conn = Bdd.GerarConexao();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.Parameters.Add("@usuario", MySqlDbType.String).Value = usuario;
                command.Parameters.Add("@senha", MySqlDbType.String).Value = senha;
                command.CommandText = "INSERT INTO login (usuario,senha) values (@usuario,@senha)";
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Usuário cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro" + ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public bool retornaDados(string usuario, string senha)
        {
            string[] dados = new string[3];
            MySqlConnection conn = Bdd.GerarConexao();
            MySqlDataReader reader;

            try
            {
                conn.Open();
                var comander = conn.CreateCommand();
                comander.Parameters.Add("@usuario", MySqlDbType.String).Value = usuario;
                comander.Parameters.Add("@senha", MySqlDbType.String).Value = senha;
                comander.CommandText = "select *from login where usuario=@usuario and senha=@senha";
                reader = comander.ExecuteReader();
                return reader.HasRows ? true : false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro");
            }
            return false;
        }
        public string[] dadosCliente(string usuario, string senha)

        {
            string[] dados = new string[2];
            MySqlConnection conn = Bdd.GerarConexao();
            MySqlDataReader reader;
            try
            {
                conn.Open();
                var commander = conn.CreateCommand();
                commander.Parameters.Add("@usuario", MySqlDbType.String).Value = usuario;
                commander.Parameters.Add("@senha", MySqlDbType.String).Value = senha;
                commander.CommandText = "select *from login where usuario=@usuario and senha=@senha";
                reader = commander.ExecuteReader();
                while (reader.Read())
                {
                    dados[0] = reader[0].ToString();
                    dados[1] = reader[1].ToString();
                }
                reader.Close();
                return dados;

            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao tentar abrir conexão");
                return null;
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        public string[] informacoesCliente(string id)
        {
            string[] dados = new string[2];
            MySqlConnection conn = Bdd.GerarConexao();
            MySqlDataReader reader;
            try
            {
                conn.Open();
                var commander = conn.CreateCommand();
                commander.Parameters.Add("@id", MySqlDbType.String).Value = id;
                commander.CommandText = "select id,usuario from login where id=@id";
                reader = commander.ExecuteReader();
                while (reader.Read())
                {
                    dados[0] = reader[0].ToString();
                    dados[1] = reader[1].ToString();
                }
                reader.Close();
                return dados;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao tentar abrir conexão");
                return null;
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public void atualizarTarefa(string id,string texto)
        {
            MySqlConnection conn = Bdd.GerarConexao();
            try
            {
                conn.Open();
                var commander = conn.CreateCommand();
                commander.Parameters.Add("@id", MySqlDbType.String).Value = id;
                commander.Parameters.Add("@texto", MySqlDbType.String).Value = texto;
                commander.CommandText = "update tarefa set descricao_tarefa = @texto where id = @id";
                commander.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Atualização realizada com sucesso");

            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro");
            }
            finally
            {
                conn.Close();
            }

        }
        public void excluirTarefa(string id)
        {
            MySqlConnection conn = Bdd.GerarConexao();
            try
            {
                conn.Open();
                var commander = conn.CreateCommand();
                commander.Parameters.Add("id", MySqlDbType.String).Value = id;
                commander.CommandText = "delete from tarefa where id = @id";
                commander.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Tarefa excluida com sucesso");

            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro");
            }
            finally
            {
                conn.Close();
            }

        }

        public void inserirNovaTarefa(Tarefa tarefa)
        {
            MySqlConnection conn = Bdd.GerarConexao();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.Parameters.Add("@descricao", MySqlDbType.String).Value = tarefa.getDescricao();
                command.Parameters.Add("@tipo", MySqlDbType.String).Value = tarefa.getTipo();
                command.Parameters.Add("@dono", MySqlDbType.String).Value = tarefa.getIdDono();
                command.CommandText = "insert into tarefa (descricao_tarefa,tipo,id_cliente) values(@descricao,@tipo,@dono)";
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Tarefa incluida com sucesso");

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro");
            }
            finally
            {
                conn.Close();
            }

        }

        public string [] retornaIdTarefa(string usuario, int quantidade)
        {
            MySqlConnection conn = Bdd.GerarConexao();
            MySqlDataReader reader;
            string[] ids = new string[quantidade];
            int contador = 0;

            try
            {
             
                conn.Open();
                var comander = conn.CreateCommand();
                comander.Parameters.Add("@usuario", MySqlDbType.Int32).Value = int.Parse(usuario);
                comander.CommandText = "select tarefa.id from tarefa inner join login on tarefa.id_cliente = login.id where tarefa.id_cliente = @usuario";

                reader = comander.ExecuteReader();
                while (reader.Read())
                {
                    ids[contador] = reader[0].ToString();
                    contador++;
                }
                reader.Close();
                return ids;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro");
                return null;
            }
            finally
            {
                conn.Close();

            }

        }
 
        public string [] dadosTarefas(string usuario)
        {
            
            MySqlConnection conn = Bdd.GerarConexao();
            MySqlDataReader reader;

            try
            {
              
                conn.Open();
                var comander = conn.CreateCommand();
                comander.Parameters.Add("@usuario", MySqlDbType.Int32).Value = int.Parse(usuario);
                comander.CommandText = "select count(tarefa.id) from tarefa inner join login on tarefa.id_cliente = login.id where tarefa.id_cliente = @usuario";
        
                reader = comander.ExecuteReader();
                reader.Read();
                int quantidade = int.Parse(reader[0].ToString());
               var ids = retornaIdTarefa(usuario, quantidade);
                return ids;
               
        
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro");
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public string descricao(string id)
        {
            MySqlConnection conn = Bdd.GerarConexao();
            MySqlDataReader reader;

            try
            {

                conn.Open();
                var comander = conn.CreateCommand();
                comander.Parameters.Add("@id", MySqlDbType.String).Value = id;
                comander.CommandText = "select descricao_tarefa from tarefa where id = @id";
                reader = comander.ExecuteReader();
                reader.Read();
                return reader[0].ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro");
                return null;
            }
            finally
            {
                conn.Close();
            }


        }
    }

       
    }
    

  


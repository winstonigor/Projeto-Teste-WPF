using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Aplicacao
{
    // obter a conexão com o banco de dados
    class Acesso
    {
        public static SqlConnection getConexaoSQLServer()
        {
            string strCon = GetConnectionStringByNome("BDTESTE");

            if (strCon == null)
                throw new Exception("String de conexão não localizada.");

            SqlConnection con = new SqlConnection(strCon);
            return con;
        }

        /// <summary>
        /// Fecha a conexao se estiver aberta
        /// </summary>
        /// <param name="conexao"></param>
        public static void closeConexaoSQLServer(SqlConnection conexao)
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }

       
        /// Retorna uma string conexao armazenada no arquivo de configuração
        /// Retorna null se não encontrar

        static string GetConnectionStringByNome(string nome)
        {
            // Assume o null
            string valorRetorno = null;

            // Procura pelo nome na seção connectionStrings
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[nome];

            // Se encontrou retorna a string 
            if (settings != null)
                valorRetorno = settings.ConnectionString;

            return valorRetorno;
        }


        // Verifica se um usuário ja esta cadastrado
        private static bool verificaUsuario(string user)
        {
            SqlDataReader dr = null;
            SqlConnection con = getConexaoSQLServer();
            string sql = "Select * from userdata where usuario='" + user + "'";
            try {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows) {
                    return false;
                }
                else {
                    return true;
                }

            }
            catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// retorna um datatable com todos os Fornecedores
        /// </summary>
        /// <returns></returns>
        public static DataTable getTabela()
        {
            SqlConnection con = null;
            try {
                con = getConexaoSQLServer();
                con.Open();
                SqlCommand comm = new SqlCommand("Select * from Fornecedor", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                closeConexaoSQLServer(con);
            }
        }
    }

}
